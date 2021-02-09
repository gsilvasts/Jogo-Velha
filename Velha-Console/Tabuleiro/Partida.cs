using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Velha_Console
{
    public class Partida
    {
        public Jogador Jogador { get; set; }
        public int Movimento { get; set; }
        public Tabuleiro Tab { get; set; }
        public int Rodada { get; set; }
        public int Placar { get; set; }
        public bool Terminada { get; set; }
        public int Resultado { get; set; }

        public Partida()
        {
            Jogador = new Jogador();
            Tab = new Tabuleiro();
            Rodada = 1;
            Terminada = false;
            Resultado = 0;
            Jogador.JogadorAtual = 1;
        }

        //Valida a jogada e marca o tabuleiro
        public void Jogada(int movimento)
        {
            while (Tab.Matriz[movimento] == 'X' || Tab.Matriz[movimento] == 'O')
            {
                Console.Clear();
                Tabuleiro();
                Console.WriteLine("\n");
                Console.WriteLine("Desculpe a posição {0} já está marcada com {1}", movimento, Tab.Matriz[movimento]);
                Console.WriteLine("\n");
                Console.Write("Informe a próxima Jogada: ");
                movimento = int.Parse(Console.ReadLine());
            }

            if (Jogador.JogadorAtual == 1)
            {
                Tab.Matriz[movimento] = 'X';
            }
            else
            {
                Tab.Matriz[movimento] = 'O';
            }

            MudaJogador();
        }

        //Retorna o vencedor da partida
        public void RetornarVencedor()
        {
            if (Resultado == 1)
            {

                Console.WriteLine("O jogador {0} venceu!", Jogador.JogadorAtual);

                if (Jogador.JogadorAtual == 1)
                {
                    Jogador.PtJogador1++;
                }
                else
                {
                    Jogador.PtJogador2++;
                }
            }
            else
            {
                Console.WriteLine("Deu velha!");
                Jogador.Empate++;
            }
        }

        //Valida se deve ser iniciada uma nova partida
        public void TerminaPartida(string retorno)
        {
            while (!retorno.Equals("S") && !retorno.Equals("s") && !retorno.Equals("N") && !retorno.Equals("n"))
            {
                Console.Clear();
                Console.WriteLine("Valor inserido não é valido, Escolha S para sim ou N para não!");
                Console.WriteLine("S/N: ");
                retorno = Console.ReadLine();
            }
            if (retorno.Equals("S") || retorno.Equals("s"))
            {
                Terminada = false;
            }
            else if (retorno.Equals("N") || retorno.Equals("n"))
            {
                Terminada = true;
                Console.Clear();
                if (Jogador.PtJogador1 > Jogador.PtJogador2)
                {
                    Console.WriteLine("O vencedor foi o jogador 1!");
                }
                else
                {
                    Console.WriteLine("O vencedor foi o jogador 2!");
                }
                Console.WriteLine("Aperte Enter para encerrar o jogo!");
                Console.Read();
            }

            Jogador.JogadorAtual = 1;
        }

        //Valida o próximo jogador
        public void MudaJogador()
        {
            if (Jogador.JogadorAtual == 1)
            {
                Jogador.JogadorAtual = 2;
            }
            else
            {
                Jogador.JogadorAtual = 1;
            }
        }

        //Monta o tabuleiro
        public void Tabuleiro()
        {
            Console.Clear();
            Console.WriteLine("Jogador 1: X e Jogador 2: O");
            Console.WriteLine("Jogador {0}: ", Jogador.JogadorAtual);
            Console.WriteLine("\n");
            Console.WriteLine("_________________ ");
            Console.WriteLine("     |     |     | ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  |", Tab.Matriz[1], Tab.Matriz[2], Tab.Matriz[3]);
            Console.WriteLine("_____|_____|_____| ");
            Console.WriteLine("     |     |     | ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  |", Tab.Matriz[4], Tab.Matriz[5], Tab.Matriz[6]);
            Console.WriteLine("_____|_____|_____| ");
            Console.WriteLine("     |     |     | ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  |", Tab.Matriz[7], Tab.Matriz[8], Tab.Matriz[9]);
            Console.WriteLine("_____|_____|_____| ");
            Console.WriteLine("\n");
            Console.WriteLine("_________________ ");
            Console.WriteLine("Rodada: {0} ", Rodada);
            Console.WriteLine("_________________ ");
            Console.WriteLine("Placar");
            Console.WriteLine("Jogador 1: {0} | Jogador 2: {1} | Empates: {2} ", Jogador.PtJogador1, Jogador.PtJogador2, Jogador.Empate);
            Console.WriteLine("\n");
            Console.Write("Digite a posição desejada (1-9): ");            
        }

        //Limpa os valores do tabuleiro para nova rodada
        public void LimparTabuleiro()
        {
            Tab.Matriz[1] = '1';
            Tab.Matriz[2] = '2';
            Tab.Matriz[3] = '3';
            Tab.Matriz[4] = '4';
            Tab.Matriz[5] = '5';
            Tab.Matriz[6] = '6';
            Tab.Matriz[7] = '7';
            Tab.Matriz[8] = '8';
            Tab.Matriz[9] = '9';
        }

        public int ChecarVencedor()
        {
            //Verifica se há ganhador na horzontal
            for (int horizontal = 1; horizontal < 8; horizontal += 3)
            {
                if (Tab.Matriz[horizontal] == Tab.Matriz[horizontal + 1] && Tab.Matriz[horizontal] == Tab.Matriz[horizontal + 2])
                {
                    return 1;
                }
            }

            //Verifica se há ganhador na vertical
            for (int vertical = 1; vertical <= 3; vertical++)
            {
                if (Tab.Matriz[vertical] == Tab.Matriz[vertical + 3] && Tab.Matriz[vertical] == Tab.Matriz[vertical + 6])
                {
                    return 1;
                }
            }

            //Verifica se há ganhador nas diagonais
            if (Tab.Matriz[1] == Tab.Matriz[5] && Tab.Matriz[5] == Tab.Matriz[9])
            {
                return 1;
            }
            else if (Tab.Matriz[3] == Tab.Matriz[5] && Tab.Matriz[5] == Tab.Matriz[7])
            {
                return 1;
            }


            //Verifica se deu velha
            else if (Tab.Matriz[1] != '1' && Tab.Matriz[2] != '2' && Tab.Matriz[3] != '3' && Tab.Matriz[4] != '4' && Tab.Matriz[5] != '5' && Tab.Matriz[6] != '6' && Tab.Matriz[7] != '7' && Tab.Matriz[8] != '8' && Tab.Matriz[9] != '9')
            {
                return -1;
            }

            else
            {
                return 0;
            }
        }
    }
}
