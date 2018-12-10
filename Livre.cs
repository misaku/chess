using System;
using System.Text;
namespace chessFatec
{
    class Livre : Peca
    {

        public Livre(int id, int tipo, int linha, int coluna)
        {
            Id = id;
            Simbolo = '*';
            Nome = "Vazio";
            Tipo = tipo;
            Last = Start = GeraPosicao(linha, coluna);

        }

        public override void mostrarMovimentos(Tabuleiro t)
        {

            throw new NotImplementedException();
        }

        public override bool validarMovimento(Peca.Position final)
        {
                return true;
        }
    }
}