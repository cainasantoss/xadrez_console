﻿using System;
using board;
using xadrez;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MatchXadrez match = new MatchXadrez();

                while (!match.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintBoard(match.Tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + match.Shift);
                        Console.WriteLine("Aguardando jogador: " + match.CurrentPlayer);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origin = Screen.ReadPositionXadrez().ToPosition();
                        match.ValidatePositionOrigin(origin);

                        bool[,] PossiblePosition = match.Tab.Pie(origin).PossibleMoves();

                        Console.Clear();
                        Screen.PrintBoard(match.Tab, PossiblePosition);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position target = Screen.ReadPositionXadrez().ToPosition();
                        match.ValidadePositionTarget(origin, target);

                        match.MakeGamble(origin, target);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
