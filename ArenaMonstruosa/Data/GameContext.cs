using ArenaMonstruosa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ArenaMonstruosa.Data
{
    public class GameContext : DbContext
    {
        public DbSet<Jogador> Jogadores { get; set; }

        public DbSet<Batalha> Batalhas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(    
                "Server=localhost;Database=ArenaMonstruosaDB;Trusted_Connection=True;TrustServerCertificate=True;"
             );
        }
    }
}
