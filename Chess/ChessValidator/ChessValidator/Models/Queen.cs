using System;

namespace ChessValidator.Models
{
    public class Queen : Piece
    {
        public override string Name { get { return "Q"; } }

        public override bool Move(Piece[,] tabla, string mutarePiesa)
        {
            var startY = mutarePiesa[0] - 'a';
            var startX = Int32.Parse(mutarePiesa[1].ToString()) - 1;

            var endY = mutarePiesa[3] - 'a';
            var endX = Int32.Parse(mutarePiesa[4].ToString()) - 1;

            var startPiesa = tabla[startX, startY];
            var endPiesa = tabla[endX, endY];

            //Console.WriteLine("Regina:" + startPiesa.Name);
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
                                Console.WriteLine("Piese pe traiectrie11!");
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
                                Console.WriteLine("Piese pe traiectrie12!");
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
                            Console.WriteLine(startX + " " + i);
                            if (tabla[i, startY] != null)
                            {
                                Console.WriteLine("Piese pe traiectrie1!");
                                Console.WriteLine(i + " " + startY );
                                Console.WriteLine(tabla[i, startY].Name);
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
                                Console.WriteLine("Piese pe traiectrie2!");
                                return false;
                            }
                        }
                    }

                    return true;
                }

                //merge in diagonale
                if (Math.Abs(endX - startX) == Math.Abs(endY - startY) && (endPiesa == null || endPiesa.color != startPiesa.color))
                {
                    //piese pe traiectorie

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
                                    Console.WriteLine("SUS-DREAPTA are piese");
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
                                    Console.WriteLine("JOS-DREAPTA are piese");
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
                                    Console.WriteLine("SUS-STANGA are piese");
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
                                    Console.WriteLine("JOS-STANGA are piese");
                                    return false;
                                }

                                startX--;
                                startY--;
                            }

                        }

                    }
                    
                    return true;
                }

                return false;
            }
        }
    }
}
