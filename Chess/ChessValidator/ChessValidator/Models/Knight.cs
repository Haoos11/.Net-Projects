//CAL
using System;

namespace ChessValidator.Models
{
    public class Knight : Piece
    {
        public override string Name { get { return "N"; } }

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

                if (((endX == startX + 2 && endY == startY + 1) || (endX == startX + 1 && endY == startY + 2)) && (endPiesa == null || endPiesa.color != startPiesa.color))
                {
                    //Console.WriteLine("Cal se muta bine");
                    return true;
                }

                if (((endX == startX - 2 && endY == startY - 1) || (endX == startX - 1 && endY == startY - 2)) && (endPiesa == null || endPiesa.color != startPiesa.color))
                {
                    //Console.WriteLine("Cal se muta bine");
                    return true;
                }

                if (((endX == startX - 2 && endY == startY + 1) || (endX == startX + 1 && endY == startY - 2)) && (endPiesa == null || endPiesa.color != startPiesa.color))
                {
                    //Console.WriteLine("Cal se muta bine");
                    return true;
                }

                if (((endX == startX + 2 && endY == startY - 1) || (endX == startX - 1 && endY == startY + 2)) && (endPiesa == null || endPiesa.color != startPiesa.color))
                {
                    //Console.WriteLine("Cal se muta bine");
                    return true;
                }

            }

            return false;
        }
    }
}
