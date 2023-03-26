using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class BoundsKeeper
    {
        private int height;
        private int width;

        public BoundsKeeper(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }

        public bool xIsInBounds(int x, int radius) 
        {
            bool retValue = false;
            int ctrl = 0;

            if (x + radius <= width)
            {
                ctrl++;
            }

            if (x - radius >= 0)
            {
                ctrl++;
            }

            if(ctrl == 2)
            {
                retValue = true;
            }

            return retValue;
        }

        public bool yIsInBounds(int y, int radius) 
        {
            bool retValue = false;
            int ctrl = 0;

            if (y + radius <= height) 
            {
                ctrl++;
            }

            if (y - radius >= 0)
            {
                ctrl++;
            }

            if(ctrl == 2)
            {
                retValue = true;
            }

            return retValue;
        }
    }
}
