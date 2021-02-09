using System;
using System.Threading;
using Velha_Console;

namespace Velha_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Partida partida = new Partida();

            while (!partida.Terminada)
            {
                do
                {
                    partida.Tabuleiro();
                    partida.Movimento = int.Parse(Console.ReadLine());
                    partida.Jogada(partida.Movimento);                    

                    partida.Resultado = partida.ChecarVencedor();                                       

                } while (partida.Resultado != 1 && partida.Resultado != -1);

                partida.MudaJogador();
                Console.Clear();
                partida.Tabuleiro();
                partida.RetornarVencedor();
                Console.WriteLine("Nova Partida? S/N ");
                string retorno = Console.ReadLine();
                partida.TerminaPartida(retorno);
                partida.LimparTabuleiro();
                Console.Clear();
                partida.Rodada++;
            }

        }

    }
}
