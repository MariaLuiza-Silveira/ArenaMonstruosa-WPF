using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ArenaMonstruosa.Data;
using ArenaMonstruosa.Controllers;
using ArenaMonstruosa.Models;
using System.Windows.Threading;


namespace ArenaMonstruosa
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadJogadores();
            LoadComboBoxJogadores();
            LoadBatalhas();
            LoadPersonagens();
        }

        private void LoadComboBoxJogadores()
        {
            using (var db = new Data.GameContext())
            {
                var jogadores = db.Jogadores.ToList();

                cbJogador1.ItemsSource = jogadores;
                cbJogador2.ItemsSource = jogadores;

                cbJogador1.DisplayMemberPath = "Nome";
                cbJogador2.DisplayMemberPath = "Nome";
            }
        }
        private void LoadJogadores()
        {
            
            var listaJogadores = controller.GetJogadores();

            
            foreach (var j in listaJogadores)
            {
                string nomeFicheiro = j.Nome.Replace(" ", "").Replace("ã", "a");

                j.Imagem = $"/Imagens/{nomeFicheiro}Icon.jpg";
            }

            dgJogadores.ItemsSource = listaJogadores;
        }
        private void cbJogador1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbJogador1.SelectedItem is Jogador j)
            {
                string nomeFicheiro = j.Nome.Replace(" ", "").Replace("ã", "a");
                imgJ1.Source = new BitmapImage(new Uri($"pack://application:,,,/Imagens/{nomeFicheiro}Icon.jpg"));

                txtHP1.Text = $"HP: {j.Vida}";
                txtATK1.Text = $"ATK: {j.Ataque}";
                txtDEF1.Text = $"DEF: {j.Defesa}";
            }
        }

        private void cbJogador2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbJogador2.SelectedItem is Jogador j)
            {
                string nomeFicheiro = j.Nome.Replace(" ", "").Replace("ã", "a");
                imgJ2.Source = new BitmapImage(new Uri($"pack://application:,,,/Imagens/{nomeFicheiro}Icon.jpg"));

                txtHP2.Text = $"HP: {j.Vida}";
                txtATK2.Text = $"ATK: {j.Ataque}";
                txtDEF2.Text = $"DEF: {j.Defesa}";
            }
        }
        private readonly JogadorController controller = new JogadorController();

        private void LimparCampos()
        {
            cbNome.SelectedItem = null;

            txtVida.Clear();
            txtAtaque.Clear();
            txtDefesa.Clear();

            dgJogadores.SelectedItem = null;
            jogadorSelecionado = null;

            cbNome.Focus();
        }
        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (cbNome.SelectedItem == null)
            {
                MessageBox.Show("Selecione um personagem.");
                return;
            }
            try
            {
                Jogador jogador = new Jogador
                {
                    Nome = ((Jogador)cbNome.SelectedItem)?.Nome,
                    Vida = int.Parse(txtVida.Text),
                    Ataque = int.Parse(txtAtaque.Text),
                    Defesa = int.Parse(txtDefesa.Text)
                };

                controller.AdicionarJogador(jogador);

                LoadJogadores();
                LoadComboBoxJogadores(); 
                LimparCampos();

                MessageBox.Show("Jogador adicionado com sucesso!");
            }
            catch
            {
                MessageBox.Show("Preencha todos os campos corretamente.");
            }
        }
        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            LimparCampos();
        }
        private void dgJogadores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgJogadores.SelectedItem is Jogador j)
            {
                jogadorSelecionado = j;

                
                var personagemOriginal = cbNome.Items.Cast<Jogador>().FirstOrDefault(p => p.Nome == j.Nome);
                cbNome.SelectedItem = personagemOriginal;

                txtVida.Text = j.Vida.ToString();
                txtAtaque.Text = j.Ataque.ToString();
                txtDefesa.Text = j.Defesa.ToString();
            }
        }
        private Jogador jogadorSelecionado;

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (jogadorSelecionado == null)
            {
                MessageBox.Show("Selecione um jogador primeiro.");
                return;
            }

            if (!int.TryParse(txtVida.Text, out int vida) ||
                !int.TryParse(txtAtaque.Text, out int ataque) ||
                !int.TryParse(txtDefesa.Text, out int defesa))
            {
                MessageBox.Show("Vida, Ataque e Defesa devem ser números.");
                return;
            }

            if (cbNome.SelectedItem == null)
            {
                MessageBox.Show("Selecione um personagem.");
                return;
            }

            using (var db = new Data.GameContext())
            {
                var jogador = db.Jogadores.Find(jogadorSelecionado.Id);

                if (jogador != null)
                {
                    jogador.Nome = ((Jogador)cbNome.SelectedItem).Nome;
                    jogador.Vida = vida;
                    jogador.Ataque = ataque;
                    jogador.Defesa = defesa;

                    db.SaveChanges();
                }
            }

            LoadJogadores();
            LoadComboBoxJogadores();
            LoadBatalhas();
            LimparCampos();

            MessageBox.Show("Jogador atualizado com sucesso!");
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (jogadorSelecionado == null)
            {
                MessageBox.Show("Selecione um jogador primeiro.");
                return;
            }

            var result = MessageBox.Show(
                $"Tens a certeza que queres eliminar o jogador {jogadorSelecionado.Nome}?",
                "Confirmar Eliminação",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.No)
                return;

            try
            {
                using (var db = new Data.GameContext())
                {
                    
                    var jogador = db.Jogadores.FirstOrDefault(j => j.Id == jogadorSelecionado.Id);

                    if (jogador != null)
                    {
                        db.Jogadores.Remove(jogador);
                        db.SaveChanges();

                        MessageBox.Show("Jogador eliminado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("O jogador já não existe na base de dados.");
                    }
                }

                
                LoadJogadores();
                LoadComboBoxJogadores(); 
                LimparCampos();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Não foi possível eliminar o jogador.\nMotivo: {ex.InnerException?.Message ?? ex.Message}",
                                "Erro ao Eliminar",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }
        private int CalcularDano(int ataque, int defesa)
        {
            return Math.Max(1, ataque - defesa);
        }

        private double CalcularTurnos(int vida, int dano)
        {
            return (double)vida / dano;
        }
        private void LoadPersonagens()
        {
            cbNome.ItemsSource = new List<Jogador>
            {
                new Jogador { Nome = "Fada", Imagem = "Imagens/FadaIcon.jpg" },
                new Jogador { Nome = "Dragão", Imagem = "Imagens/DragaoIcon.jpg" },
                new Jogador { Nome = "Orc", Imagem = "Imagens/OrcIcon.jpg" },
                new Jogador { Nome = "Cavaleiro", Imagem = "Imagens/CavaleiroIcon.jpg" },
                new Jogador { Nome = "Feiticeiro", Imagem = "Imagens/FeiticeiroIcon.jpg" },
                new Jogador { Nome = "Elfo", Imagem = "Imagens/ElfoIcon.jpg" },
                new Jogador { Nome = "Troll", Imagem = "Imagens/TrollIcon.jpg" },
                new Jogador { Nome = "Rei", Imagem = "Imagens/ReiIcon.jpg" },
                new Jogador { Nome = "Duende", Imagem = "Imagens/DuendeIcon.jpg" },
                new Jogador { Nome = "Gigante", Imagem = "Imagens/GiganteIcon.jpg" }
            };
        }
        private void LoadBatalhas()
        {
            using (var db = new Data.GameContext())
            {
                var batalhas = db.Batalhas
                    .Join(db.Jogadores,
                          b => b.Jogador1Id,
                          j => j.Id,
                          (b, j1) => new { b, j1 })

                    .Join(db.Jogadores,
                          bj => bj.b.Jogador2Id,
                          j2 => j2.Id,
                          (bj, j2) => new BatalhaView
                          {
                              Jogador1 = bj.j1.Nome,
                              Jogador2 = j2.Nome,
                              Vencedor =
                                  bj.b.VencedorId == bj.j1.Id ? bj.j1.Nome :
                                  bj.b.VencedorId == j2.Id ? j2.Nome :
                                  "Empate",
                              DataDaBatalha = bj.b.DataDaBatalha
                          })
                    .ToList();

                dgBatalhas.ItemsSource = batalhas;

                
                btnLimparHistorico.IsEnabled = batalhas.Count > 0;
            }
        }

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "Tens a certeza que queres sair do jogo?",
                "Confirmar saída",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        private void BtnLimparHistorico_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "Tens a certeza que queres apagar todo o histórico de batalhas?",
                "Confirmação",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (result == MessageBoxResult.No)
                return;

            using (var db = new Data.GameContext())
            {
                db.Batalhas.RemoveRange(db.Batalhas);
                db.SaveChanges();
            }

            LoadBatalhas();

            MessageBox.Show("Histórico limpo com sucesso!");
        }
        private void SalvarBatalha(Jogador j1, Jogador j2, string vencedor)
        {
            using (var db = new Data.GameContext())
            {
                var batalha = new Batalha
                {
                    Jogador1Id = j1.Id,
                    Jogador2Id = j2.Id,
                    VencedorId = vencedor == j1.Nome ? j1.Id :
                                 vencedor == j2.Nome ? j2.Id : 0,
                    DataDaBatalha = DateTime.Now
                };

                db.Batalhas.Add(batalha);
                db.SaveChanges();
            }
        }

        private async void BtnBatalha_Click(object sender, RoutedEventArgs e)
        {
            
            if (cbJogador1.SelectedItem == null || cbJogador2.SelectedItem == null)
            {
                MessageBox.Show("Selecione dois jogadores.");
                return;
            }

            if (cbJogador1.SelectedItem == cbJogador2.SelectedItem)
            {
                MessageBox.Show("Escolha jogadores diferentes.");
                return;
            }

            Jogador j1 = (Jogador)cbJogador1.SelectedItem;
            Jogador j2 = (Jogador)cbJogador2.SelectedItem;

            
            lblNomeVencedor.Text = "---";
            imgVencedor.Source = null;

            
            txtBatalhaStatus.Text = "⚔ Preparando batalha...";
            await Task.Delay(1000);

            txtBatalhaStatus.Text = "🔥 Início do combate!";
            await Task.Delay(1000);

            int danoJ1 = CalcularDano(j1.Ataque, j2.Defesa);
            int danoJ2 = CalcularDano(j2.Ataque, j1.Defesa);

            int turnosJ1 = (int)Math.Ceiling(CalcularTurnos(j1.Vida, danoJ2));
            int turnosJ2 = (int)Math.Ceiling(CalcularTurnos(j2.Vida, danoJ1));

            txtBatalhaStatus.Text = "💥 Troca de golpes...";
            await Task.Delay(1500);

            
            string vencedorNome;
            Jogador objetoVencedor = null;

            if (turnosJ1 > turnosJ2)
            {
                vencedorNome = j1.Nome;
                objetoVencedor = j1;
            }
            else if (turnosJ2 > turnosJ1)
            {
                vencedorNome = j2.Nome;
                objetoVencedor = j2;
            }
            else
            {
                vencedorNome = "Empate";
            }

            txtBatalhaStatus.Text = "🏁 Finalizando batalha...";
            await Task.Delay(1000);

            
            if (objetoVencedor != null)
            {

                string nomeFicheiroVencedor = objetoVencedor.Nome.Replace(" ", "").Replace("ã", "a");
                imgVencedor.Source = new BitmapImage(new Uri($"pack://application:,,,/Imagens/{nomeFicheiroVencedor}Pers.jpg"));

                lblNomeVencedor.Text = objetoVencedor.Nome.ToUpper();
                txtBatalhaStatus.Text = $"O lendário {objetoVencedor.Nome} resistiu bravamente e conquistou a glória na Arena Mítica!";
            }
            else
            {
                lblNomeVencedor.Text = "EMPATE";
                txtBatalhaStatus.Text = "O combate terminou sem sobreviventes. Ambas as forças colapsaram!";
            }

            
            MessageBox.Show(
                $"⚔ BATALHA FINAL ⚔\n\n" +
                $"{j1.Nome}: {turnosJ1} turnos\n" +
                $"{j2.Nome}: {turnosJ2} turnos\n\n" +
                $"🏆 Vencedor: {vencedorNome}"
            );

            
            SalvarBatalha(j1, j2, vencedorNome);
            LoadBatalhas();
        }
        private string ObterImagemVencedor(string nome)
        {
            switch (nome)
            {
                case "Cavaleiro":
                    return "Imagens/CavaleiroPers.jpg";

                case "Feiticeiro":
                    return "Imagens/FeiticeiroPers.jpg";

                case "Orc":
                    return "Imagens/OrcPers.jpg";

                case "Elfo":
                    return "Imagens/ElfoPers.jpg";

                case "Troll":
                    return "Imagens/TrollPers.jpg";

                case "Dragão":
                    return "Imagens/DragaoPers.jpg";

                case "Rei":
                    return "Imagens/ReiPers.jpg";

                case "Duende":
                    return "Imagens/DuendePers.jpg";

                case "Fada":
                    return "Imagens/FadaPers.jpg";

                case "Gigante":
                    return "Imagens/GigantePers.jpg";

                default:
                    return "";
            }
        }
        
        private void BtnHistoria_Click(object sender, RoutedEventArgs e)
        {
            HistoriaWindow janela = new HistoriaWindow();
            janela.ShowDialog();
        }
    }
}
