using System;
using System.Text;
namespace chessFatec
{
    class Rei : Peca
    {
        public Rei(int id, int tipo, int linha, int coluna)
        {
            Id = id;
            this.Simbolo = 'K';
            this.Nome = "Rei";
            Tipo = tipo;
            Last = Start = GeraPosicao(linha, coluna);

        }

        private void validacao(int i, int col, int tipo, Tabuleiro t)
        {
            if (i >= 0 && col >= 0 && i < 8 && col < 8)
            {
                if (t.Tbl[i, col] == null)
                {
                    t.Tbl[i, col] = new Livre(-1, 3, i, col);
                    t.Tbl[i, col].Atacado = true;
                }
                else
                {
                    if (t.Tbl[i, col].Tipo != tipo)
                        t.Tbl[i, col].Atacado = true;
                }
            }

        }
        public override void mostrarMovimentos(Tabuleiro t)
        {

            Selecionada = true;
            int Col = Last.Coluna;
            if (Col >= 0 && Col < 8)
            {
                int Lin = Last.Linha;
                for (int i = -1; i < 2; i++)
                {
                    if (i != 0)
                    {
                        int l = Lin + i;

                        int c = Col + i;

                        validacao(Lin, c, Tipo, t);
                        validacao(l, Col, Tipo, t);
                        validacao(l, c, Tipo, t);
                        l = Lin + (i*(-1));
                        validacao(l, c, Tipo, t);
                    }
                }
                t.Imprimir();
                // throw new NotImplementedException();
            }
            Selecionada = false;
        }

        override public bool validarMovimento(Peca.Position final)
        {
            return true;
        }
    }
}