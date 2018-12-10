using System;
using System.Text;
namespace chessFatec
{
    class Peao : Peca
    {
        public bool DirPassante { get; set; }
        public bool DoPassante { get; set; }

        public Peao(int id, int tipo, int linha, int coluna)
        {
            Id = id;
            Simbolo = 'P';
            Nome = "Peão";
            Tipo = tipo;
            Last = Start = GeraPosicao(linha, coluna);
            Turnos = 0;

        }

        public override void mostrarMovimentos(Tabuleiro t)
        {
            int st = 1;
            if (Turnos == 0)
                st = 2;
            Selecionada = true;
            int Col = Last.Coluna;
            if (Col >= 0 && Col < 8)
            {
                int Lin = Last.Linha;
                int colA = Col + 1;
                int colB = Col - 1;

                if (Tipo == 0)
                {
                    for (int i = Lin; i <= (Lin + st); i++)
                    {
                        if (t.Tbl[i, Col] == null)
                        {
                            t.Tbl[i, Col] = new Livre(-1, 3, i, t.getValorColunaChar(Col));
                            t.Tbl[i, Col].Atacado = true;
                        }
                    }
 
                    if (colA < 8 && t.Tbl[Lin+1, colA] != null && t.Tbl[Lin+1, colA].Tipo != Tipo)
                        t.Tbl[Lin+1, colA].Atacado = true;
                    if (colB >= 0 && t.Tbl[Lin+1, colB] != null && t.Tbl[Lin+1, colB].Tipo != Tipo)
                        t.Tbl[Lin+1, colB].Atacado = true;
                }
                else
                {
                    for (int i = Lin; i >=(Lin - st); i--)
                    {
                        if (t.Tbl[i, Col] == null)
                        {
                            t.Tbl[i, Col] = new Livre(-1, 3, i, t.getValorColunaChar(Col));
                            t.Tbl[i, Col].Atacado = true;
                        }
                    }

                    if (colA < 8 && t.Tbl[Lin-1, colA] != null && t.Tbl[Lin-1, colA].Tipo != Tipo)
                        t.Tbl[Lin-1, colA].Atacado = true;
                    if (colB >= 0 && t.Tbl[Lin-1, colB] != null && t.Tbl[Lin-1, colB].Tipo != Tipo)
                        t.Tbl[Lin-1, colB].Atacado = true;
                }

                t.Imprimir();
            }
            Selecionada = false;
        }

        public override bool validarMovimento(Peca.Position final)
        {

            return true;
        }
    }
}