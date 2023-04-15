using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public override int Position_X { get => position_x; set { position_x = value;  NotifyPropertyChanged(); } }
        public override int Position_Y { get => position_y; set { position_y = value; NotifyPropertyChanged(); } }
        public override int Radius => radius;

        public override event PropertyChangedEventHandler? PropertyChanged;

        public override void Update(Object s, PropertyChangedEventArgs e)
        {
            IBall ball = (IBall) s;
            switch (e.PropertyName)
            {
                case nameof(Position_X):
                {
                    this.Position_X = ball.Position_X;
                    break; 
                }

                case nameof(Position_Y):
                {
                    this.Position_Y = ball.Position_Y;
                    break;
                }
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string? callerProperty = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerProperty));
        }
    }
}
