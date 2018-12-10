using System;
using System.Text;
namespace chessFatec
{
    class Torre : Peca
    {
        public Torre(int id, int tipo, int linha, int coluna)
        {
            Id = id;
            this.Simbolo = 'T';
            this.Nome = "Torre";
            Tipo = tipo;
            Last = Start = GeraPosicao(linha, coluna);

        }
        public static void trataMovimento(int col, int lin, int tipo, Tabuleiro t)
        {
            for (int i = lin + 1; i < 8; i++)
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
                    break;
                }
            }
            for (int i = lin - 1; i >= 0; i--)
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
                    break;
                }
            }
            for (int i = col + 1; i < 8; i++)
            {
                if (t.Tbl[lin, i] == null)
                {
                    t.Tbl[lin, i] = new Livre(-1, 3, lin, i);
                    t.Tbl[lin, i].Atacado = true;
                }
                else
                {
                    if (t.Tbl[lin, i].Tipo != tipo)
                        t.Tbl[lin, i].Atacado = true;
                    break;
                }
            }
            for (int i = col - 1; i >= 0; i--)
            {
                if (t.Tbl[lin, i] == null)
                {
                    t.Tbl[lin, i] = new Livre(-1, 3, lin, i);
                    t.Tbl[lin, i].Atacado = true;
                }
                else
                {
                    if (t.Tbl[lin, i].Tipo != tipo)
                        t.Tbl[lin, i].Atacado = true;
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
                Torre.trataMovimento(Col, Last.Linha, Tipo, t);
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