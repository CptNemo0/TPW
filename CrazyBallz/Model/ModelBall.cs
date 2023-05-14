using Logic;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    internal class ModelBall : IModelBall, INotifyPropertyChanged
    {
        private float position_x;
        private float position_y;
        private int radius;
        private string colour;

        public ModelBall(float position_x, float position_y, int radius)
        {
            this.position_x = position_x;
            this.position_y = position_y;
            this.radius = radius;
            this.colour = String.Empty;
        }

        public override float Position_X { get => position_x; set { position_x = value; NotifyPropertyChanged(); } }
        public override float Position_Y { get => position_y; set { position_y = value; NotifyPropertyChanged(); } }
        public override int Radius => radius;
        public override string Colour { get => colour; set => colour = value; }

        public override event PropertyChangedEventHandler? PropertyChanged;

        public override void Update(Object s, PropertyChangedEventArgs e)
        {
            LogicBall ball = (LogicBall)s;
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

        private void NotifyPropertyChanged([CallerMemberName] string? propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override void DetermineColour(int mass)
        {
            switch (mass)
            {
                case 1:
                    this.colour = "#F0DDBC";
                    break;

                case 2:
                    this.colour = "#D6C5A8";
                    break;

                case 3:
                    this.colour = "#BDAE94";
                    break;

                case 4:
                    this.colour = "#A69982";
                    break;

                case 5:
                    this.colour = "#8C816E";
                    break;

                case 6:
                    this.colour = "#706758";
                    break;

                case 7:
                    this.colour = "#524B40";
                    break;

                case 8:
                    this.colour = "#38342C";
                    break;

                case 9:
                    this.colour = "#1F1C18";
                    break;

                case 10:
                    this.colour = "#0A0908";
                    break;
            }
        }
    }
}
