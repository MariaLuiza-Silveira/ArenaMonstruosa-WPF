using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaMonstruosa.Models
{
    public class BatalhaView
    {
        public string Jogador1 { get; set; }
        public string Jogador2 { get; set; }
        public string Vencedor { get; set; }
        public DateTime DataDaBatalha { get; set; }
    }
}
