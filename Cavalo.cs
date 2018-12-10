using System;
using System.Text;
namespace chessFatec
{
    class Cavalo : Peca
    {
        public Cavalo(int id, int tipo, int linha, int coluna)
        {
            Id = id;
            this.Simbolo = 'C';
            this.Nome = "Cavalo";
            Tipo = tipo;
            Last = Start = GeraPosicao(linha, coluna);

        }
        protected void trataMovimento(int i, int j, Tabuleiro t)
        {
            if (i < 8 && i >= 0 && j >= 0 && j <8)
            {
                if (t.Tbl[i, j] == null)
                {
                    t.Tbl[i, j] = new Livre(-1, 3, i, j);
                    t.Tbl[i, j].Atacado = true;
                }
                else
                {
                    if (t.Tbl[i, j].Tipo != Tipo)
                        t.Tbl[i, j].Atacado = true;
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

                int line = 0, colu=0;
                for(int l = -2; l < 3 ; l++)
                {
                    line = Lin + l;
                    if (l!=0)
                        for(int k =1; k <=2; k++)
                        {
                            if(l%2==0)
                                if (k % 2 == 0)
                                    colu = Col + 1;
                                else
                                    colu = Col - 1;
                            else
                                if(k % 2 == 0)
                                    colu = Col + 2;
                                else
                                    colu = Col - 2;
                            trataMovimento(line, colu, t);
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