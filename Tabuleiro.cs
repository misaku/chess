using System;
using System.Text;
namespace chessFatec
{
    class Tabuleiro
    {
        //ATRIBUTOS BASE PARA MUDANÇA DE COR
        protected ConsoleColor ColorBack { get; set; } = ConsoleColor.White;
        protected ConsoleColor ColorFore { get; set; } = ConsoleColor.Black;
        public Peca[,] Tbl { get; set; } = new Peca[8,8];

        public void preparaTurno()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if(Tbl[i, j]!=null)
                        if (Tbl[i, j].Tipo == 3)
                            Tbl[i, j] = null;
                        else if (Tbl[i, j].Atacado)
                            Tbl[i, j].Atacado = false;
            setCorBase(ConsoleColor.Black, ConsoleColor.White);
            aplicarCorBase();
            Console.Clear();
        }
        public Tabuleiro()
        {
            int p = 1;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i < 2 || i > 5)
                    {

                        int branco = 0;
                        if (p > 16)
                            branco = 1;
                        Peca bs;

                        if (p >= 9 && p <= 24)
                            bs = new Peao(p, branco, i, j);
                        else 
                        if (p == 1 || p == 8 || p == 25 || p == 32)
                            bs = new Torre(p, branco, i, j);
                        else if (p == 2 || p == 7 || p == 26 || p == 31)
                            bs = new Cavalo(p, branco, i, j);
                        else if (p == 3 || p == 6 || p == 27 || p == 30)
                            bs = new Bispo(p, branco, i, j);
                        else if (p == 4 || p == 28)
                            bs = new Rainha(p, branco, i, j);
                        else
                            bs = new Rei(p, branco, i + 1, j);
                        ///modificacao para teste
                        /*if (p >= 9 && p <= 24)
                            Tbl[i, j] = null;
                        else*/
                            Tbl[i, j] = bs;
                        p++;
                    }

                }
            }
        }
        //METODOS PARA MUDANÇA DE COR
        protected void mudarCor(ConsoleColor colorBack, ConsoleColor colorFore)
        {
            Console.BackgroundColor = colorBack;
            mudarCorTxt(colorFore);
        }
        protected void mudarCorTxt(ConsoleColor colorFore)
        {
            Console.ForegroundColor = colorFore;
        }
        protected void aplicarCorBase()
        {
            mudarCor(ColorBack, ColorFore);
        }
        protected void setCorBase(ConsoleColor colorBack, ConsoleColor colorFore)
        {
            ColorBack = colorBack;
            ColorFore = colorFore;
        }
        protected void aplicarCorBaseGray()
        {
            mudarCor(ConsoleColor.White, ConsoleColor.Black);
        }

        protected void autoCorQuadrado(int linha, int coluna)
        {
            //METODO QUE MUDA COR DO CAMPO AUTOMATICAMENTE
            if (linha % 2 == 0)
                if (coluna % 2 == 0)
                    setCorBase(ConsoleColor.Gray, ConsoleColor.Black);
                else
                    setCorBase(ConsoleColor.DarkGray, ConsoleColor.Black);
            else
               if (coluna % 2 == 0)
                setCorBase(ConsoleColor.DarkGray, ConsoleColor.Black);
            else
                setCorBase(ConsoleColor.Gray, ConsoleColor.Black);
            aplicarCorBase();
        }

        //METODOS DE PARA IDENTIFICAÇÃO ESTETICA DAS LINHAS E COLUNAS
        private void colunasAlfabeticas()
        {
            aplicarCorBaseGray();
            // FAZ AS COLUNAS E COLOCA AS LETRAS DE IDENTIFICAÇÃO
            Console.Write("   ");
            char first = 'A';
            for (int i = 0; i < 8; i++)
            {
                Console.Write($"    {first}    ");
                first = (char)((int)first + 1);
            }
            Console.Write("   \n");
        }
        public bool validarTurno()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (Tbl[i, j] != null)
                        if (Tbl[i, j].Tipo == 3 || Tbl[i, j].Atacado)
                            return true;
            return false;
        }
        public int getValorColuna(char s)
        {
            char first = 'A';
            for (int i = 0; i < 8; i++)
            {
                first = 'A';
                first = (char)((int)first + i);
                if (s == first)
                    return i;
            }
            return -1;
        }
        public char getValorColunaChar(int s)
        {
            char first = 'A';
            first = (char)((int)first + s);
            return first;
        }
        private void linhasIdendificadas(bool final, int linha, int sublinha)
        {
            aplicarCorBaseGray();
            // FAZ AS LINHAS E COLOCA AS LETRAS DE IDENTIFICAÇÃO
            if (sublinha == 2)
                Console.Write($" {8-linha} ");
            else
                Console.Write("   ");

            if (final)
                Console.Write("\n");

            if (!(linha == 0 && sublinha == 1))
                aplicarCorBase();
        }
        private void setCampo(string valor, int subLinha)
        {
            for (int n = 1; n <= 3; n++)
                if (n == 2 && subLinha == 2)
                    Console.Write($" {valor} ");
                else
                    Console.Write("   ");
        }
        public void Imprimir()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            colunasAlfabeticas();
            //LINHAS
            for (int linha = 0; linha < 8; linha++)
            {
                //SUBLINHAS PARA DEIXAR QUADRADO
                for (int subLinha = 1; subLinha <= 3; subLinha++)
                {
                    linhasIdendificadas(false, linha, subLinha);

                    //COLUNAS
                    for (int coluna = 0; coluna < 8; coluna++)
                    {
                        autoCorQuadrado(linha, coluna);
                        //SUBCOLUNAS PARA DEIXAR QUADRADO    
                        if (Tbl[linha, coluna] != null)
                        {
                            if (Tbl[linha, coluna].Selecionada == true)
                                mudarCorTxt(ConsoleColor.Blue);
                            else if(Tbl[linha, coluna].Tipo == 3 || Tbl[linha, coluna].Atacado)
                                mudarCorTxt(ConsoleColor.Green);
                            else if (Tbl[linha, coluna].Atacante == true)
                                mudarCorTxt(ConsoleColor.Red);
                            else if (Tbl[linha, coluna].Tipo == 1)
                                mudarCorTxt(ConsoleColor.White);




                            setCampo($"{ Tbl[linha, coluna].Simbolo}", subLinha);
                        }
                        else
                            setCampo(" ", subLinha);

                    }
                    aplicarCorBaseGray();
                    linhasIdendificadas(true, linha, subLinha);
                }

            }
            colunasAlfabeticas();
            
        }
    }
}