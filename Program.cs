using System;
using System.Text;
namespace chessFatec
{
    class Program
    {
        public static void Main(string[] args)
        {
            Jogo j = new Jogo();
            j.NovoJogo();
            j.Iniciar();
        }
    }
}