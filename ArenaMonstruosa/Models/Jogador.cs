using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaMonstruosa.Models
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; }
        public int Defesa { get; set; }
        public string Imagem { get; set; }
    }
}

