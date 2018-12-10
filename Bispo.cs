using System;
using System.Text;
namespace chessFatec
{
    class Bispo : Peca
    {
        public Bispo(int id,int tipo, int linha, int coluna)
        {
            Id = id;
            this.Simbolo = 'B';
            this.Nome = "Bispo";
            Tipo = tipo;
            Last = Start = GeraPosicao(linha, coluna);

        }

        public static void trataMovimento(int col, int lin, int tipo,Tabuleiro t)
        {
            for (int i = lin + 1, j = col + 1; i < 8 && j < 8; i++, j++)
            {
                if (t.Tbl[i, j] == null)
                {
                    t.Tbl[i, j] = new Livre(-1, 3, i, j);
                    t.Tbl[i, j].Atacado = true;
                }
                else
                {
                    if (t.Tbl[i, j].Tipo != tipo)
                        t.Tbl[i, j].Atacado = true;
                    break;
                }
            }
            for (int i = lin - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (t.Tbl[i, j] == null)
                {
                    t.Tbl[i, j] = new Livre(-1, 3, i, j);
                    t.Tbl[i, j].Atacado = true;
                }
                else
                {
                    if (t.Tbl[i, j].Tipo != tipo)
                        t.Tbl[i, j].Atacado = true;
                    break;
                }
            }

            for (int i = lin + 1, j = col - 1; i < 8 && j >= 0; i++, j--)
            {
                if (t.Tbl[i, j] == null)
                {
                    t.Tbl[i, j] = new Livre(-1, 3, i, j);
                    t.Tbl[i, j].Atacado = true;
                }
                else
                {
                    if (t.Tbl[i, j].Tipo != tipo)
                        t.Tbl[i, j].Atacado = true;
                    break;
                }
            }
            for (int i = lin - 1, j = col + 1; i >= 0 && j < 8; i--, j++)
            {
                if (t.Tbl[i, j] == null)
                {
                    t.Tbl[i, j] = new Livre(-1, 3, i, j);
                    t.Tbl[i, j].Atacado = true;
                }
                else
                {
                    if (t.Tbl[i, j].Tipo != tipo)
                        t.Tbl[i, j].Atacado = true;
                    break;
                }
            }
        }
        public override void mostrarMovimentos(Tabuleiro t)
        {
 
            Selecionada = true;
            int Col = Last.Coluna;
            if (Col >= 0 && Col < 8)
            {
                Bispo.trataMovimento(Col, Last.Linha,Tipo,t);
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