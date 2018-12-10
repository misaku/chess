using System;
using System.Text;
namespace chessFatec
{
     class Jogo
    {
        protected Jogador A { get; set; }
        protected Jogador B { get; set; }
        protected Tabuleiro TAB { get; set; }

        protected Jogador Vez { get; set; }
        protected Jogador Branco { get; set; }

        protected int Turno { get; set; }


        protected bool Rodando { get; set; } = true;

        public Jogo()
        {

        }

        protected void setJogadores()
        {
            Console.WriteLine("Informe o nome do Jogador 1: ");
            A = new Jogador();
            A.Nome = Console.ReadLine();
            A.Vitorias = 0;

            Console.WriteLine("Informe o nome do Jogador 2: ");
            B = new Jogador();
            B.Nome = Console.ReadLine();
            B.Vitorias = 0;
        }
        protected void Imprimir()
        {
            Console.Clear();
        }
        public void NovoJogo()
        {
            Console.Clear();
            setJogadores();
            TAB = new Tabuleiro();
        }
        protected void goSetTurno(int lOld, int cOld)
        {
            bool continuar = true;
            int lin = 0;
            int col = -1;
            while (continuar)
            {
                lin = -1;
                col = -1;
                while (!(lin > 0 && lin <= 8))
                {
                    Console.WriteLine($"Informe a linha Destino(1-8):");
                    string res = Console.ReadLine();
                    if (int.TryParse(res, out lin))
                    {
                        lin = int.Parse(res);
                    }
    
                }
                lin = 8 - lin;

                while (!(col >= 0 && col < 8))
                {
                    Console.WriteLine($"Informe a Coluna Destino(A-H):");
                    char c = Console.ReadKey().KeyChar;
                    c = Char.ToUpper(c);
                    col = TAB.getValorColuna(c);
                    Console.WriteLine("");
                }

                if (TAB.Tbl[lin, col]==null||!(TAB.Tbl[lin, col].Tipo==3|| TAB.Tbl[lin, col].Atacado))
                {
                    Console.WriteLine($"Movimento errado!");
                    continue;
                }

                int s = -1;
                while (s < 0)
                {
                    Console.WriteLine($"Deseja Confirmar o Movimento [S,N]");
                    char sc = Console.ReadKey().KeyChar;
                    sc = Char.ToUpper(sc);
                    if (sc == 'S')
                        s = 1;
                    else if (sc == 'N')
                        s = 0;
                    Console.WriteLine("");
                }
                if (s == 1)
                    continuar = false;
            }
            TAB.Tbl[lin, col] = TAB.Tbl[lOld, cOld];
            TAB.Tbl[lOld, cOld] = null;
            TAB.Tbl[lin, col].setPosicao(lin, col);
            TAB.Tbl[lin, col].Turnos++;

        }
        protected void goTurno()
        {
            bool continuar = true;
            int lin = 0;
            int col = -1;
            while (continuar)
            {
                lin = -1;
                col = -1;
                Console.WriteLine($"{Vez.Nome} selecione uma peça");

                while (!(lin > 0 && lin <= 8))
                {
                    Console.WriteLine($"Informe a linha(1-8):");
                    string res = Console.ReadLine();
                    if (int.TryParse(res, out lin))
                    {
                        lin = int.Parse(res);
                    }
                }
                lin = 8 - lin;

                while (!(col >= 0 && col < 8))
                {
                    Console.WriteLine($"Informe a linha(A-H):");
                    char c = Console.ReadKey().KeyChar;
                    c = Char.ToUpper(c);
                    col = TAB.getValorColuna(c);
                    Console.WriteLine("");
                }
                int tp = 0;
                if(Vez == Branco)
                {
                    tp = 1;
                }
                if (TAB.Tbl[lin, col].Tipo != tp)
                {
                    Console.WriteLine($"Peça não perce a você!");
                    continue;
                }
                TAB.preparaTurno();
                TAB.Tbl[lin, col].mostrarMovimentos(TAB);
                if (!TAB.validarTurno())
                {
                    Console.WriteLine($"Peça sem possibilidade de movimentos!");
                    continue;
                }

                int s = -1;
                while (s<0)
                {
                    Console.WriteLine($"Deseja Confirmar a Seleção [S,N]");
                    char sc = Console.ReadKey().KeyChar;
                    sc = Char.ToUpper(sc);
                    if (sc == 'S')
                        s = 1;
                    else if (sc == 'N')
                        s = 0;
                    Console.WriteLine("");
                }
                if (s == 1)
                    continuar = false;
                else
                    TAB.preparaTurno();
            }
            goSetTurno(lin, col);
            TAB.preparaTurno();

        }
        public void Iniciar()
        {

            Turno = 1;
            Vez = A;
            Branco = A;
            while (Rodando)
            {
                Console.Clear();
                Console.WriteLine($"Jogador 1: {A.Nome}\t Jogador 2:{B.Nome}");
                TAB.Imprimir();
                goTurno();
                if (Vez == A)
                    Vez = B;
                else
                    Vez = A;
            }
           
        }


    }
}