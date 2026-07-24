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
using System.Windows.Media.Effects; 
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ArenaMonstruosa
{
    public partial class HistoriaWindow : Window
    {
        private int indice = 0;

        private List<PersonagemHistoria> personagens = new List<PersonagemHistoria>()
        {
            new PersonagemHistoria
            {
                Nome="Fada",
                CorHex="#FF00EA", 
                Imagem="/Imagens/FadaPers.jpg",
                Historia="🧚‍♀️ Origem Divina: Nasceu do reflexo da lua em um cristal de mana pura.\r\n🧚‍♀️ Ameaça ao Lar: Viu sua floresta ser invadida por monstros e dragões da Arena.\r\n🧚‍♀️ Magia de Suporte: Usa luz mística para curar aliados e aumentar suas defesas.\r\n🧚‍♀️ Entrada no Torneio: Decidiu lutar na Arena para proteger seu povo e trazer a paz.\r\n🧚‍♀️ Poder Oculto: É frágil e tem pouco HP, mas compensa com alta velocidade e feitiços brutais."
            },
            new PersonagemHistoria
            {
                Nome="Dragão",
                CorHex="#FF1A1A", 
                Imagem="/Imagens/DragaoPers.jpg",
                Historia="🐉 Linhagem Ancestral: Último descendente dos dragões negros que moldaram as montanhas de fogo.\r\n🐉 Desafio Aceito: Entrou na Arena em busca de oponentes dignos que aguentem seu poder.\r\n🐉 Sopro Devastador: Seu ataque incendeia o campo de batalha, reduzindo armaduras a cinzas.\r\n🐉 Escamas de Titânio: Possui uma das maiores defesas da Arena, bloqueando golpes com facilidade.\r\n🐉 Fúria Indomável: Quanto mais a batalha demora, mais destrutivos e rápidos ficam seus ataques."
            },
            new PersonagemHistoria
            {
                Nome="Orc",
                CorHex="#2E8B57", 
                Imagem="/Imagens/OrcPers.jpg",
                Historia="💀 Sangue de Ferro: Criado nas tribos bárbaras do norte, onde apenas os mais fortes sobrevivem.\r\n💀 Sede de Glória: Entrou na Arena para provar que é o guerreiro mais temido de todos os reinos.\r\n💀 Força Bruta: Seus golpes com o machado pesado quebram qualquer escudo ou barreira.\r\n💀 Resistência Implacável: Possui um HP massivo e ignora a dor para continuar lutando até o fim.\r\n💀 Espírito de Batalha: Fica ainda mais forte e agressivo quando seu sangue começa a ferver no combate."
            },
            new PersonagemHistoria
            {
                Nome="Cavaleiro",
                CorHex="#00BFFF", 
                Imagem="/Imagens/CavaleiroPers.jpg",
                Historia="🛡️ Juramento de Aço: Cavaleiro sagrado que dedicou sua vida a proteger o reino e os inocentes.\r\n🛡️ Missão de Honra: Entrou na Arena para derrotar as ameaças monstruosas e testar seu código de conduta.\r\n🛡️ Escudo Lendário: Sua defesa impenetrável consegue absorver os maiores impactos de dragões e orcs.\r\n🛡️ Combate Tático: Equilibra perfeitamente um HP robusto com contra-ataques precisos e cirúrgicos.\r\n🛡️ Determinação Inabalável: Nunca recua e ganha bônus de armadura sempre que protege um aliado em perigo."
            },
            new PersonagemHistoria
            {
                Nome="Feiticeiro",
                CorHex="#9400D3", 
                Imagem="/Imagens/FeiticeiroPers.jpg",
                Historia="🔮 Mente Arcana: Estudioso dos mistérios proibidos que domina os elementos cósmicos.\r\n🔮 Busca pelo Conhecimento: Entrou na Arena para testar seus feitiços mais perigosos em alvos reais.\r\n🔮 Magia Elemental: Dispara rajadas de fogo e gelo que causam danos massivos de longa distância.\r\n🔮 Defesa Mística: Tem HP baixo, mas usa escudos de energia pura para mitigar os golpes físicos.\r\n🔮 Foco Absoluto: Consegue canalizar mana para aumentar o poder de ataque a cada turno que passa."
            },
            new PersonagemHistoria
            {
                Nome="Elfo",
                CorHex="#00FF7F", 
                Imagem="/Imagens/ElfoPers.jpg",
                Historia="🏹 Olhar Clínico: Mestre arqueiro das florestas milenares, com sentidos超 apurados.\r\n🏹 Defensor da Natureza: Entrou na Arena para caçar as criaturas que desequilibram o ecossistema.\r\n🏹 Precisão Mortal: Seus disparos de flecha encontram os pontos fracos exatos dos inimigos.\r\n🏹 Agilidade Pura: Possui pouca defesa, mas compensa esquivando-se de quase todos os ataques.\r\n🏹 Flechas Encantadas: Usa magias de vento para atacar à distância e prender os oponentes."
            },
            new PersonagemHistoria
            {
                Nome="Troll",
                CorHex="#FF8C00", 
                Imagem="/Imagens/TrollPers.jpg",
                Historia="👹 Regeneração Brutal: Criatura das cavernas profundas capaz de curar suas feridas instantaneamente.\r\n👹 Instinto Selvagem: Entrou na Arena guiado apenas pela fome e pelo prazer da destruição.\r\n👹 Pele de Pedra: Possui um HP gigantesco e uma resistência natural que cansa os adversários.\r\n👹 Ataque Esmagador: Usa porretes enormes ou as próprias mãos para nocautear os inimigos.\r\n👹 Frenesi de Sangue: Fica mais rápido e recupera ainda mais vida quando está perto de derrotar o rival."
            },
            new PersonagemHistoria
            {
                Nome="Rei",
                CorHex="#FFD700", 
                Imagem="/Imagens/ReiPers.jpg",
                Historia="👑 Poder Supremo: O soberano da Arena que dita as leis do combate e comanda o campo de batalha.\r\n👑 Trono em Jogo: Decidiu lutar pessoalmente para provar aos súditos que nenhum monstro é maior que sua coroa.\r\n👑 Espada Real: Seus golpes desferem um dano equilibrado e impõem respeito aos adversários.\r\n👑 Armadura de Ouro: Ostenta uma defesa pesada e um HP digno de um líder que recusa cair.\r\n👑 Comando Estratégico: Inspira aliados e enfraquece o ataque dos inimigos apenas com sua presença imponente."
            },
            new PersonagemHistoria
            {
                Nome="Duende",
                CorHex="#32CD32", 
                Imagem="/Imagens/DuendePers.jpg",
                Historia="💰 Mente Ambiciosa: Pequeno, astuto e obcecado por moedas de ouro e tesouros escondidos.\r\n💰 Interesse Comercial: Entrou na Arena para saquear os guerreiros derrotados e faturar alto com as apostas.\r\n💰 Golpes Trapaceiros: Ataca pelas costas com adagas envenenadas, focando nos pontos cegos dos rivais.\r\n💰 Evasão Ligeira: Tem HP baixíssimo, mas é tão minúsculo e rápido que os monstros mal conseguem acertá-lo.\r\n💰 Bolsa de Truques: Usa bombas de fumaça e armadilhas para atordoar os inimigos e escapar do perigo."
            },
            new PersonagemHistoria
            {
                Nome="Gigante",
                CorHex="#FF4500", 
                Imagem="/Imagens/GigantePers.jpg",
                Historia="🌋 Força Titânica: Criatura colossal cujo único passo é capaz de fazer tremer todo o chão da Arena.\r\n🌋 Desafio de Peso: Entrou no torneio simplesmente porque nenhum lugar no mundo conseguia conter seu tamanho.\r\n🌋 HP Monumental: Possui a maior barra de vida de todo o jogo, aguentando turnos inteiros de ataques seguidos.\r\n🌋 Golpe Devastador: Ataca esmagando tudo à sua frente, ignorando boa parte da defesa e dos escudos inimigos.\r\n🌋 Lentidão Pesada: Ataque e defesa gigantes, mas sua velocidade é a menor entre todos os guerreiros."
            }
        };

        public HistoriaWindow()
        {
            InitializeComponent();
            MostrarPersonagem();
        }

        private void MostrarPersonagem()
        {
            var personagemAtual = personagens[indice];

            txtNome.Text = personagemAtual.Nome.ToUpper();
            txtHistoria.Text = personagemAtual.Historia;
            txtContador.Text = $"{indice + 1} / {personagens.Count}";

            imgPersonagem.Source = new BitmapImage(
                new Uri(personagemAtual.Imagem, UriKind.Relative));

            // --- APLICAÇÃO DINÂMICA DE CORES E BRILHO ---

            // Converte a string Hexadecimal para uma Cor válida do WPF
            Color corPersonagem = (Color)ColorConverter.ConvertFromString(personagemAtual.CorHex);
            SolidColorBrush pincelCor = new SolidColorBrush(corPersonagem);

            // 1. Altera a cor da fonte do Nome
            txtNome.Foreground = pincelCor;

            // 2. Altera a cor da Borda (Apenas se ela tiver o Name="bordaPersonagem" no seu XAML)
            if (bordaPersonagem != null)
            {
                bordaPersonagem.BorderBrush = pincelCor;
            }

            // 3. Cria e aplica o efeito de Brilho Neon (Glow) baseado na cor do personagem
            DropShadowEffect efeitoBrilho = new DropShadowEffect
            {
                Color = corPersonagem,
                Direction = 0,      // Brilha igualmente para todos os lados
                ShadowDepth = 0,    // Mantém o foco no centro da palavra
                Opacity = 0.9,      // Intensidade do brilho forte
                BlurRadius = 15     // O alcance do "esfumaçado" do brilho
            };
            txtNome.Effect = efeitoBrilho;
        }

        private void BtnAnterior_Click(object sender, RoutedEventArgs e)
        {
            indice--;
            if (indice < 0) indice = personagens.Count - 1;
            MostrarPersonagem();
        }

        private void BtnProximo_Click(object sender, RoutedEventArgs e)
        {
            indice++;
            if (indice >= personagens.Count) indice = 0;
            MostrarPersonagem();
        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show(
                "Tens a certeza que pretendes sair do jogo?",
                "Confirmar saída",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (resultado == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }
    }

    public class PersonagemHistoria
    {
        public string Nome { get; set; }
        public string CorHex { get; set; } // Propriedade que carrega a cor única de cada classe
        public string Imagem { get; set; }
        public string Historia { get; set; }
    }
}