//REGE
using System;

namespace ChessValidator.Models
{
    public class King : Piece
    {
        public override string Name { get { return "K"; } }

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!BUG (mutat rege in dreapta sau stanga pionului)
        public bool MoveToCheck(Piece[,] tabla, string mutarePiesa)
        {
            var startY = mutarePiesa[0] - 'a';
            var startX = Int32.Parse(mutarePiesa[1].ToString()) - 1;

            var endY = mutarePiesa[3] - 'a';
            var endX = Int32.Parse(mutarePiesa[4].ToString()) - 1;

            var startPiesa = tabla[startX, startY];
            var endPiesa = tabla[endX, endY];

            var Rege = startPiesa;
            var bendPiesa = endPiesa;
            bool rez = false;

            tabla[startX, startY] = null;
            tabla[endX, endY] = null;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //if (tabla[i, j] != null && tabla[i, j].color != this.color && tabla[i,j].Name != "K")
                    if (tabla[i, j] != null && tabla[i, j].color != Rege.color && tabla[i, j].Name != "K")
                    {
                        string pathToKing = ((char)(j + 97)).ToString() + (i+1).ToString() + "-" + mutarePiesa[3] + mutarePiesa[4];
                        //Console.WriteLine("PATH TO KING!!!!!:::: " + pathToKing);

                        var backUpPozitieViitoare = tabla[endX, endY];
                        tabla[endX, endY] = Rege;
                        //tabla[startX, startY] = null;

                        rez = tabla[i, j].Move(tabla, pathToKing);
                        if(rez == true)
                        {
                            Console.WriteLine("Muti in sah!!!!!!!!" + tabla[i,j].Name + tabla[i,j].color);
                            tabla[startX, startY] = Rege;
                            tabla[endX, endY] = bendPiesa;
                            return true;
                        }
                        //tabla[startX, startY] = Rege;
                        //tabla[endX, endY] = backUpPozitieViitoare;
                        //Console.WriteLine("Muti in sah!!!!!!!!" + tabla[i, j].Name + tabla[i, j].color);
                    }
                }
            }
            tabla[startX, startY] = Rege;
            tabla[endX, endY] = bendPiesa;
            return rez;
        }

        public bool KingToKing(Piece[,] tabla, string mutarePiesa)
        {
            var startY = mutarePiesa[0] - 'a';
            var startX = Int32.Parse(mutarePiesa[1].ToString()) - 1;
            var startPiesa = tabla[startX, startY];

            var endY = mutarePiesa[3] - 'a';
            var endX = Int32.Parse(mutarePiesa[4].ToString()) - 1;

            if (endX < 6)
            {
                //sus
                if (tabla[endX + 1, endY] != startPiesa && tabla[endX + 1, endY] == null && tabla[endX + 1, endY].Name != "K")
                {
                    Console.WriteLine("sus");
                    return true;
                }
            }

            //jos
            if (endX > 0)
            {
                if (tabla[endX - 1, endY] != startPiesa && tabla[endX - 1, endY] == null && tabla[endX - 1, endY].Name != "K")
                {
                    Console.WriteLine("jos");
                    return true;
                }
            }

            if (endY > 0)
            {
                //stanga
                if (tabla[endX, endY - 1] != startPiesa && tabla[endX, endY - 1] == null && tabla[endX, endY - 1].Name != "K")
                {
                    Console.WriteLine("stanga");
                    return true;
                }
            }
            if (endY < 6)
            {
                //dreapta
                if (tabla[endX, endY + 1] != startPiesa && tabla[endX, endY + 1] == null && tabla[endX, endY + 1].Name != "K")
                {
                    Console.WriteLine("dreapta");
                    return true;
                }
            }

            if (endX < 6 && endY > 0)
            {
                //sus stanga
                if (tabla[endX + 1, endY - 1] != startPiesa && tabla[endX + 1, endY - 1] == null && tabla[endX + 1, endY - 1].Name != "K")
                {
                    Console.WriteLine("sus stanga");
                    return true;
                }
            }

            if (endX < 6 && endY < 6)
            {
                //sus dreapta
                if (tabla[endX + 1, endY + 1] != startPiesa && tabla[endX + 1, endY + 1] == null && tabla[endX + 1, endY + 1].Name != "K")
                {
                    Console.WriteLine("sus dreapta");
                    return true;
                }
            }

            if (endX > 0 && endY > 0)
            {
                //jos stanga
                if (tabla[endX - 1, endY - 1] != startPiesa && tabla[endX - 1, endY - 1] == null && tabla[endX - 1, endY - 1].Name != "K")
                {
                    Console.WriteLine("jos stanga");
                    return true;
                }
            }

            if (endX > 0 && endY < 6)
            {
                //jos dreapta
                if (tabla[endX - 1, endY + 1] != startPiesa && tabla[endX - 1, endY + 1] == null && tabla[endX - 1, endY + 1].Name != "K")
                {
                    Console.WriteLine("jos dreapta");
                    return true;
                }
            }

            return false;

        }

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

                //if (KingToKing(tabla, mutarePiesa) == true)
                //{
                //    return false;
                //}

                //merge in stanga/dreapta
                if (startX == endX && startY != endY && (endPiesa == null || endPiesa.color != startPiesa.color) && (MoveToCheck(tabla, mutarePiesa) != true))
                {
                    //piese pe traiectorie

                    //merge la dreapta
                    if (startY == endY -1 )
                    {
                        return true;
                    }
                    //merge la stanga
                    else if (startY == endY + 1)
                    {
                        return true;
                    }

                    return false;
                }

                //merge in sus/jos
                if (startX != endX && startY == endY && (endPiesa == null || endPiesa.color != startPiesa.color) && (MoveToCheck(tabla, mutarePiesa) != true))
                {
                    //piese pe traiectorie

                    //piesa urca
                    if (startX == endX - 1)
                    {
                        return true;
                    }
                    //piesa coboara
                    else if (startX == endX +1)
                    {
                        return true;
                    }

                    return false;
                }

                //merge in diagonale
                if (Math.Abs(endX - startX) == Math.Abs(endY - startY) && (endPiesa == null || endPiesa.color != startPiesa.color) && (MoveToCheck(tabla, mutarePiesa) != true))
                {
                    //piese pe traiectorie

                    //merge la dreapta
                    if (startY == endY -1)
                    {
                        //merge in sus
                        if (startX == endX -1)
                        {
                            return true;

                        }

                        //merge in jos
                        if (startX == endX + 1)
                        {
                            return true;
                        }

                    }
                    //merge la stanga !--- SCADE Y ---!                       
                    if (startY == endY + 1)
                    {
                        //merge in sus
                        if (startX == endX - 1)
                        {
                            return true;
                        }

                        //merge in jos
                        if (startX == endX + 1)
                        {
                            return true;
                        }

                    }

                    return false;
                }

                return false;
            }
        }
    }
}
