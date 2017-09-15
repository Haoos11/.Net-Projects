using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChessValidator.InitialPositions
{
    public class InitPositions
    {
        public IList<string> Read(string White, string Black)
        {
            var white = White.Split(',').ToList<string>();
            var black = Black.Split(',').ToList<string>();

            var ListaPiese = new List<string>();

            foreach (var piesaAlba in white)
            {
                String piesa = "w" + piesaAlba;
                ListaPiese.Add(piesa);
            }

            foreach (var piesaNeagra in black)
            {
                String piesa = "b" + piesaNeagra;
                ListaPiese.Add(piesa);
            }

            return ListaPiese;
        }

    }
}
