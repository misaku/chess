using System;
using System.Text;
using System.Collections.Generic;
namespace chessFatec
{
    class Jogador
    {
        public string Nome { get; set; }
        public int Vitorias { get; set; }
        public List<Partida> Partidas { get; set; } = new List<Partida>();
    }
}