using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaMonstruosa.Models
{
    public class Batalha
    {
        public int Id { get; set; }

        public int Jogador1Id { get; set; }

        public int Jogador2Id { get; set; }

        public int VencedorId { get; set; }

        public DateTime DataDaBatalha { get; set; }
    }
}
