//TURN
using System;

namespace ChessValidator.Models
{
    public class Rook : Piece
    {
        public override string Name { get { return "R"; } }

        public override bool Move(Piece[,] tabla, string mutarePiesa)
        {
            var startY = mutarePiesa[0] - 'a';
            var startX = Int32.Parse(mutarePiesa[1].ToString()) - 1;

            var endY = mutarePiesa[3] - 'a';
            var endX = Int32.Parse(mutarePiesa[4].ToString()) - 1;

            var startPiesa = tabla[startX, startY];
            var endPiesa = tabla[endX, endY];

            //Console.WriteLine("Tura:" + startPiesa.Name);
            //Console.WriteLine("X: " + startX + " Y: " + startY);
            //Console.WriteLine("X2: " + endX + " Y2: " + endY);

            if (startPiesa == null)
            {
                return false;
            }

            if (endX <= 0 && endX > 7 && endY <= 0 && endY > 7)
            {
                Console.WriteLine("Nu poti muta in afara tablei!");
                return false;
            }
            else
            {
                if (startX == endX && startY == endY)
                {
                    Console.WriteLine("Nu poti spune pass!");
                    return false;
                }

                //merge in stanga/dreapta
                if (startX == endX && startY != endY && (endPiesa == null || endPiesa.color != startPiesa.color))
                {
                    //piese pe traiectorie

                    //merge la dreapta
                    if (startY < endY)
                    {
                        for (int i = startY + 1; i < endY; i++)
                        {
                            if (tabla[startX, i] != null)
                            {
                                Console.WriteLine("Piese pe traiectrie!");
                                return false;
                            }

                        }
                    }
                    //merge la stanga
                    else
                    {
                        for (int i = startY - 1; i > endY; i--)
                        {
                            if (tabla[startX, i] != null)
                            {
                                Console.WriteLine("Piese pe traiectrie!");
                                return false;
                            }
                        }
                    }
                    
                    return true;
                }

                //merge in sus/jos
                if (startX != endX && startY == endY && (endPiesa == null || endPiesa.color != startPiesa.color))
                {
                    //piese pe traiectorie

                    //piesa urca
                    if (startX < endX)
                    {
                        for (int i = startX + 1; i < endX; i++)
                        {
                            if (tabla[i, startY] != null)
                            {
                                Console.WriteLine("Piese pe traiectrie!");
                                return false;
                            }
                        }
                    }
                    //piesa coboara
                    else
                    {
                        for (int i = startX - 1; i > endX; i--)
                        {
                            if (tabla[i, startY] != null)
                            {
                                Console.WriteLine("Piese pe traiectrie!");
                                return false;
                            }
                        }
                    }
                    
                    return true;
                }

            }
            
            return false;

        }
    }
}
