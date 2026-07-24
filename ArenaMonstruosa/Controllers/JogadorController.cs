using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaMonstruosa.Data;
using ArenaMonstruosa.Models;
using Microsoft.EntityFrameworkCore;

namespace ArenaMonstruosa.Controllers
{
    public class JogadorController
    {
        public List<Jogador> GetJogadores()
        {
            using (var db = new GameContext())
            {
                return db.Jogadores.ToList();
            }
        }

        public void AdicionarJogador(Jogador jogador)
        {
            using (var db = new GameContext())
            {
                db.Jogadores.Add(jogador);
                db.SaveChanges();
            }
        }
    }
}
