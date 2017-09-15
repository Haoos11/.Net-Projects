//PION
using System;

namespace ChessValidator.Models
{
    public class Pawn : Piece
    {
        public override string Name { get { return "P"; } }

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
            //Iesire din tabla
            if (endX <= 0 && endX > 7 && endY <= 0 && endY > 7)
            {
                Console.WriteLine("Nu poti muta in afara tablei!");
                return false;
            }
            else
            {
                // Conditia de pass
                if (startX == endX && startY == endY)
                {
                    Console.WriteLine("Nu poti spune pass!");
                    return false;                    
                }

                //Pentru piesele albe
                if (startPiesa.color == ChessColor.White)
                {
                    //Daca e nemiscat poate merge 2 casute
                    if (startX == 1 && startY == endY && Math.Abs(startX - endX) == 2 && endPiesa == null)
                    {
                        //Daca drumul e liber
                        if (tabla[startX + 1, startY] == null)
                        {
                            //Console.WriteLine("Initial pionul poate merge 2 casute!");
                            //Console.WriteLine("ERR1");
                            return true;
                        }                        
                    }

                    //Daca e miscat merge doar una
                    if (startY == endY && startX == endX - 1 && endPiesa == null)
                    {
                        //Console.WriteLine("ERR2");
                        return true;
                    }

                    //Daca are piesa neagra in dreapta/stanga o ia
                    if (Math.Abs(startY - endY) == 1 && startX == endX - 1 && endPiesa != null && endPiesa.color == ChessColor.Black)
                    {
                        //Console.WriteLine("ERR3");
                        return true;
                    }
                }
                if (startPiesa.color == ChessColor.Black)
                {
                    //Daca e nemiscat poate merge 2 casute
                    if (startX == 6 && startY == endY && Math.Abs(startX - endX) == 2 && endPiesa == null)
                    {
                        //Daca drumul e liber
                        if (tabla[startX - 1, startY] == null)
                        {
                            //Console.WriteLine("Initial pionul poate merge 2 casute!");
                            //Console.WriteLine("ERR4");
                            return true;
                        }
                    }

                    //Daca e miscat merge doar una
                    if (startY == endY && startX == endX + 1 && endPiesa == null)
                    {
                        //Console.WriteLine("ERR5");
                        return true;
                    }

                    //Daca are piesa neagra in dreapta/stanga o ia
                    if (Math.Abs(startY - endY) == 1 && startX == endX + 1 && endPiesa != null && endPiesa.color == ChessColor.White)
                    {
                        //Console.WriteLine("ERR6");
                        return true;
                    }
                }
                //else
                //{
                //    //Console.WriteLine("Nu poti merge inapoi!");
                //    //Console.WriteLine("ERR7");
                //    return false;
                //}


            }
            //Console.WriteLine("Sfarsit");
            return false;
        }
    }
}
