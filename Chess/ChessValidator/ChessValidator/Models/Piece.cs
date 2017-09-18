using System;

namespace ChessValidator.Models
{
    public abstract class Piece
    {
        public abstract string Name { get; }
        public ChessColor color;

        public abstract bool Move(Piece[,] tabla, string mutarePiesa);

        //public bool CheckIfMove(Piece[,] tabla, string mutarePiesa)
        //{
        //    var startY = mutarePiesa[0] - 'a';
        //    var startX = Int32.Parse(mutarePiesa[1].ToString()) - 1;

        //    var endY = mutarePiesa[3] - 'a';
        //    var endX = Int32.Parse(mutarePiesa[4].ToString()) - 1;

        //    var startPiesa = tabla[startX, startY];
        //    var endPiesa = tabla[endX, endY];

        //    int Xrege = 0, Yrege = 0;

        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 8; j++)
        //        {
        //            if (tabla[i, j] != null && tabla[i, j].Name == "K" && tabla[i, j].color == startPiesa.color)
        //            {
        //                Xrege = i;
        //                Yrege = j;
        //            }
        //        }
        //    }

        //    var backUpStartPiesa = startPiesa;
        //    tabla[startX,startY] = null;
        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 8; j++)
        //        {
        //            if (tabla[i, j] != null && tabla[i, j].color != backUpStartPiesa.color)
        //            {
        //                Console.WriteLine("ERRRRRROOOOAAAAREEEEEE!!!!!!");
        //                string pathToKing = ((char)(j + 97)).ToString() + (i + 1).ToString() + "-" + ((char)(Yrege + 97)).ToString() + (Xrege+1).ToString();
        //                if (tabla[i, j].Move(tabla, pathToKing) == true)
        //                {
        //                    Console.WriteLine("Daca muti piesa ramai in sah!!!!!!!!!");
        //                    tabla[startX, startY] = backUpStartPiesa;
        //                    return true;
        //                }

        //            }
        //        }
        //    }
        //    tabla[startX, startY] = backUpStartPiesa;

        //    return false;
        //}

        public bool CheckIfMove(Piece[,] tabla, string mutarePiesa)
        {
            var startY = mutarePiesa[0] - 'a';
            var startX = Int32.Parse(mutarePiesa[1].ToString()) - 1;

            var endY = mutarePiesa[3] - 'a';
            var endX = Int32.Parse(mutarePiesa[4].ToString()) - 1;

            var startPiesa = tabla[startX, startY];
            var endPiesa = tabla[endX, endY];

            if (Move(tabla, mutarePiesa) == true)
            {
                tabla[startX, startY] = null;
                int xRege = 0, yRege = 0;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (tabla[i, j] != null && tabla[i, j].Name == "K" && tabla[i, j].color == startPiesa.color)
                        {
                            yRege = j;
                            xRege = i;
                        }
                    }
                }

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (tabla[i, j] != null && tabla[i, j].color != startPiesa.color)
                        {
                            string pathToKing = ((char)(j + 97)).ToString() + (i + 1).ToString() + "-" + ((char)(yRege + 97)).ToString() + (xRege + 1).ToString();
                            if (tabla[i, j].Move(tabla, pathToKing) == true)
                            {
                                tabla[startX, startY] = startPiesa;
                                return true;
                            }
                        }
                    }
                }
                
            }

            tabla[startX, startY] = startPiesa;
            return false;
        }

    }
}
