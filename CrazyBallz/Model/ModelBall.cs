using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class ModelBall : IModelBall
    {
        private int position_x;
        private int position_y;
        private int radius;

        public ModelBall(int position_x, int position_y, int radius)
        {
            this.position_x = position_x;
            this.position_y = position_y;
            this.radius = radius;
        }

        public override int Position_X { get => position_x; set => position_x = value; }
        public override int Position_Y { get => position_y; set => position_y = value; }
        public override int Radius => radius;
    }
}
