using System;

namespace Model
{
    public abstract class IModelBall
    {
        public static IModelBall Instantiate(int position_x, int position_y, int radius)
        {
            return new ModelBall(position_x, position_y, radius);
        }

        public abstract int Position_X { get; set; }
        public abstract int Position_Y { get; set; }
        public abstract int Radius { get; }


    }
}
