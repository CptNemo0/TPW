using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Board
    {
        private int height;
        private int width;

        public Board(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }
    }
}
