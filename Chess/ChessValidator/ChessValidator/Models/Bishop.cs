//Nebun
using System;

namespace ChessValidator.Models
{
    public class Bishop : Piece
    {
        public override string Name { get { return "B"; } }


        public override bool Move(Piece[,] tabla, string mutarePiesa)
        {
            var startY = mutarePiesa[0] - 'a';
            var startX = Int32.Parse(mutarePiesa[1].ToString()) - 1;

            var endY = mutarePiesa[3] - 'a';
            var endX = Int32.Parse(mutarePiesa[4].ToString()) - 1;

            var startPiesa = tabla[startX, startY];
            var endPiesa = tabla[endX, endY];

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
                else if (startX != endX && startY == endY)
                {
                    //Console.WriteLine("Nebunul merge doar pe diagonale!");
                    return false;
                }
                else if (startX == endX && startY != endY)
                {
                    //Console.WriteLine("Nebunul merge doar pe diagonale!");
                    return false;
                }
                //merge pe diagonale si ultima piesa e nula sau are culoare diferita
                else if (Math.Abs(endX - startX) == Math.Abs(endY - startY) && (endPiesa == null || endPiesa.color != startPiesa.color))
                {
                    //merge la dreapta
                    if (startY < endY)
                    {
                        //merge in sus
                        if (startX < endX)
                        {
                            startX++;
                            startY++;

                            while (true)
                            {
                                if (startX == endX && startY == endY)
                                    break;

                                if (tabla[startX, startY] != null)
                                {
                                    //Console.WriteLine("SUS-DREAPTA are piese");
                                    return false;
                                }

                                startX++;
                                startY++;
                            }

                        }

                        //merge in jos
                        if (startX > endX)
                        {
                            startX--;
                            startY++;

                            while (true)
                            {
                                if (startX == endX && startY == endY)
                                    break;

                                if (tabla[startX, startY] != null)
                                {
                                    //Console.WriteLine("JOS-DREAPTA are piese");
                                    return false;
                                }

                                startX--;
                                startY++;
                            }
                        }
                    }
                    //merge la stanga !--- SCADE Y ---!                       
                    if (startY > endY)
                    {
                        //merge in sus
                        if (startX < endX)
                        {
                            startX++;
                            startY--;

                            while (true)
                            {
                                if (startX == endX && startY == endY)
                                    break;

                                if (tabla[startX, startY] != null)
                                {
                                    //Console.WriteLine("SUS-STANGA are piese");
                                    return false;
                                }

                                startX++;
                                startY--;
                            }
                        }

                        //merge in jos
                        if (startX > endX)
                        {
                            startX--;
                            startY--;

                            while (true)
                            {
                                if (startX == endX && startY == endY)
                                    break;

                                if (tabla[startX, startY] != null)
                                {
                                    //Console.WriteLine("JOS-STANGA are piese");
                                    return false;
                                }
                                startX--;
                                startY--;
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
