using System;
using System.ComponentModel;

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
        public abstract string Colour { get; set; }

        public abstract event PropertyChangedEventHandler? PropertyChanged;

        public abstract void Update(Object s, PropertyChangedEventArgs e);
        public abstract void DetermineColour(int mass);
    }
}
