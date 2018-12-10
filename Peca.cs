using System;
using System.Text;
namespace chessFatec
{
    abstract class Peca
    {
        public class Position
        {
            public Position(int linha, int coluna)
            {
                Coluna = coluna;
                Linha = linha;
            }

            public int Coluna { get; set; }
            public int Linha { get; set; }
        }

        protected Position Start { get; set; }
        protected Position Last { get; set; }

        public static Position GeraPosicao(int linha, int coluna)
        {
            return new Position(linha, coluna);
        }
        public void setPosicao(int linha, int coluna)
        {
            Last = new Position(linha, coluna);
        }


        public bool Atacado { get; set; }
        public bool Atacante { get; set; }
        public bool Selecionada { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public char Simbolo { get; set; }
        public int Turnos { get; set; }
        public int Tipo { get; set; }

        abstract public void mostrarMovimentos(Tabuleiro t);
        abstract public bool validarMovimento(Position final);

    }
}