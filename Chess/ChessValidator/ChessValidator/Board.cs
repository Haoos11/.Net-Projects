using ChessModel;
using ChessValidator.InitialPositions;
using ChessValidator.Models;
using System;
using System.Collections.Generic;
using static ChessValidator.Models.Piece;

namespace ChessValidator
{
    public class SBoard: IChessEngine
    {
        //lista pozitiilor din fisiere
        InitPositions ListaPopulare = new InitPositions();
        IList<string> ListaPiese;
   
        //creare tabla sah goala
        public Piece[,] TablaSah = new Piece[8, 8];

        //generare tabla
        public Piece[,] StartGame(string WhitePath, string BlackPath)
        {
            TablaSah = new Piece[8, 8];
            ListaPiese = ListaPopulare.Read(WhitePath, BlackPath);

            foreach (var piesa in ListaPiese)
            {
                if (piesa[0] == 'w')
                {
                    if (piesa[1] == 'K')
                    {
                        var piesaSah = new King();
                        piesaSah.color = ChessColor.White;

                        TablaSah[Int32.Parse(piesa[3].ToString())-1, piesa[2]-'a'] = piesaSah;
                    }

                    if (piesa[1] == 'Q')
                    {
                        var piesaSah = new Queen();
                        piesaSah.color = ChessColor.White;

                        TablaSah[Int32.Parse(piesa[3].ToString()) - 1, piesa[2] - 'a'] = piesaSah;
                    }

                    if (piesa[1] == 'B')
                    {
                        var piesaSah = new Bishop();
                        piesaSah.color = ChessColor.White;

                        TablaSah[Int32.Parse(piesa[3].ToString()) - 1, piesa[2] - 'a'] = piesaSah;
                    }

                    if (piesa[1] == 'N')
                    {
                        var piesaSah = new Knight();
                        piesaSah.color = ChessColor.White;

                        TablaSah[Int32.Parse(piesa[3].ToString()) - 1, piesa[2] - 'a'] = piesaSah;
                    }

                    if (piesa[1] == 'P')
                    {
                        var piesaSah = new Pawn();
                        piesaSah.color = ChessColor.White;

                        TablaSah[Int32.Parse(piesa[3].ToString()) - 1, piesa[2] - 'a'] = piesaSah;
                    }

                    if (piesa[1] == 'R')
                    {
                        var piesaSah = new Rook();
                        piesaSah.color = ChessColor.White;

                        TablaSah[Int32.Parse(piesa[3].ToString()) - 1, piesa[2] - 'a'] = piesaSah;
                    }
                }
                else
                {
                    if (piesa[1] == 'K')
                    {
                        var piesaSah = new King();
                        piesaSah.color = ChessColor.Black;

                        TablaSah[Int32.Parse(piesa[3].ToString()) - 1, piesa[2] - 'a'] = piesaSah;
                    }

                    if (piesa[1] == 'Q')
                    {
                        var piesaSah = new Queen();
                        piesaSah.color = ChessColor.Black;

                        TablaSah[Int32.Parse(piesa[3].ToString()) - 1, piesa[2] - 'a'] = piesaSah;
                    }

                    if (piesa[1] == 'B')
                    {
                        var piesaSah = new Bishop();
                        piesaSah.color = ChessColor.Black;

                        TablaSah[Int32.Parse(piesa[3].ToString()) - 1, piesa[2] - 'a'] = piesaSah;
                    }

                    if (piesa[1] == 'N')
                    {
                        var piesaSah = new Knight();
                        piesaSah.color = ChessColor.Black;

                        TablaSah[Int32.Parse(piesa[3].ToString()) - 1, piesa[2] - 'a'] = piesaSah;
                    }

                    if (piesa[1] == 'P')
                    {
                        var piesaSah = new Pawn();
                        piesaSah.color = ChessColor.Black;

                        TablaSah[Int32.Parse(piesa[3].ToString()) - 1, piesa[2] - 'a'] = piesaSah;
                    }

                    if (piesa[1] == 'R')
                    {
                        var piesaSah = new Rook();
                        piesaSah.color = ChessColor.Black;

                        TablaSah[Int32.Parse(piesa[3].ToString()) - 1, piesa[2] - 'a'] = piesaSah;
                    }

                }

            }
            
            return TablaSah;
        }

        public void Initialize(string csvWhites, string csvBlacks)
        {
            StartGame(csvWhites, csvBlacks);
        }

        public Piece[,] Muta(Piece[,] tabla, string mutarePiesa)
        {
            var startY = mutarePiesa[0] - 'a';
            var startX = Int32.Parse(mutarePiesa[1].ToString()) - 1;

            var endY = mutarePiesa[3] - 'a';
            var endX = Int32.Parse(mutarePiesa[4].ToString()) - 1;

            var startPiesa = tabla[startX, startY];
            var endPiesa = tabla[endX, endY];

            if (startPiesa == null)
                return null;

            if (startPiesa.Move(tabla, mutarePiesa) == true /*&& !startPiesa.CheckIfMove(tabla, mutarePiesa)*/)
            {
                tabla[endX, endY] = startPiesa;
                tabla[startX, startY] = null;

                return tabla;
            }

            return null;
        }

        public bool CanMove(string move)
        {
            //pt ce piesa se aplica mutarea
            var startX = Int32.Parse(move[1].ToString()) - 1;
            //Console.WriteLine("startx board: " + startX);
            var startY = move[0] - 'a';
            //Console.WriteLine("starty board: " + startY);

            var endY = move[3] - 'a';
            //Console.WriteLine("Endy board: " + endY);
            var endX = Int32.Parse(move[4].ToString()) - 1;
            //Console.WriteLine("Endx board: " + endX);

            if (TablaSah[startX, startY] == null)
            {
                //Console.WriteLine("Nu exista piesa pe aceasta pozitie");
                return true;
            }
            else
            {
                if (TablaSah[startX, startY].Name == "K")
                {
                    Piece king = new King();
                    return king.Move(TablaSah, move);
                }

                if (TablaSah[startX, startY].Name == "Q")
                {
                    Piece queen = new Queen();
                    return queen.Move(TablaSah, move);
                }

                if (TablaSah[startX, startY].Name == "B")
                {
                    Piece bishop = new Bishop();
                    return bishop.Move(TablaSah, move);
                }

                if (TablaSah[startX, startY].Name == "N")
                {
                    Piece knight = new Knight();
                    return knight.Move(TablaSah, move);
                }

                if (TablaSah[startX, startY].Name == "P")
                {
                    Piece pawn = new Pawn();
                    return pawn.Move(TablaSah, move);
                }

                if (TablaSah[startX, startY].Name == "R")
                {
                    Piece rook = new Rook();
                    return rook.Move(TablaSah, move);
                }
            }

            return false; 
        }
    }
}
