using System;
using System.Text.RegularExpressions;

namespace ChessValidator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var engine = new SBoard();
            var tabla = engine.StartGame("Kg1,Qc2,Rc1,Rd1,Bh5,Be3,Ne4,Pb3,Pd4,Pf2,Pg2,Ph2", "Kg6,Qe7,Ra8,Rf8,Bg7,Bc8,Nd7,Nb6,Pa5,Pb7,Pc6,Pe6,Ph6");

            Console.WriteLine("  a        " + "b        " + "c        " + "d        " + "e        " + "f        " + "g        " + "h        ");
            for (int i = 7; i >= 0 ; i--) {
                Console.Write(i+1 + "|");
                for(int j=0; j<8; j++)
                {
                    
                    if (i % 2 == 0 && j % 2 == 1 || i % 2 == 1 && j % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }

                    if (tabla[i, j] == null)
                    {
                        Console.Write("        ");
                    }
                    else
                    {
                        Console.Write(tabla[i,j].color + " " + tabla[i, j].Name + " ");                                              
                    }
                    
                }
                Console.WriteLine();
                    
            }

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("Introduceti mutarea de forma a1-a2: ");
                var mutare = Console.ReadLine();

                if (mutare.Length != 5)
                {
                    Console.WriteLine("Input incorect!!!");
                    continue;
                }

                //engine.Muta(tabla, mutare);

                Console.WriteLine("  a        " + "b        " + "c        " + "d        " + "e        " + "f        " + "g        " + "h        ");
                for (int i = 7; i >= 0; i--)
                {
                    Console.Write(i + 1 + "|");
                    for (int j = 0; j < 8; j++)
                    {

                        if (i % 2 == 0 && j % 2 == 1 || i % 2 == 1 && j % 2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                        }

                        if (tabla[i, j] == null)
                        {
                            Console.Write("        ");
                        }
                        else
                        {
                            Console.Write(tabla[i, j].color + " " + tabla[i, j].Name + " ");
                        }

                    }
                    Console.WriteLine();

                }
                Console.WriteLine(engine.CanMove(mutare));
            }

            Console.ReadLine();
        }
    }
}
