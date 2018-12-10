using System;
using System.Text;
namespace chessFatec
{
    class Rainha : Peca
    {
        public Rainha(int id, int tipo, int linha, int coluna)
        {
            Id = id;
            this.Simbolo = 'Q';
            this.Nome = "Rainha";
            Tipo = tipo;
            Last = Start = GeraPosicao(linha, coluna);

        }

        public override void mostrarMovimentos(Tabuleiro t)
        {

            Selecionada = true;
            int Col = Last.Coluna;
            if (Col >= 0 && Col < 8)
            {
                Bispo.trataMovimento(Col, Last.Linha, Tipo, t);
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