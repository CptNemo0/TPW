﻿using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class ModelManager : ModelApi
    {
        private ObservableCollection<IModelBall> ModelBalls = new();
        private readonly LogicApi logicApi;

        public ModelManager(LogicApi logicApi)
        {
            this.logicApi = logicApi;
        }

        public override void RemoveAllBalls()
        {
            logicApi.RemoveAllBalls();
        }

        public override bool CreateBallAtRandomCoordinates()
        {
            return logicApi.CreateBallAtRandomCoordinates();
        }

        public override void NewRandomBalls(int n)
        {
            while (n > 0)
            {
                if (CreateBallAtRandomCoordinates())
                {
                    n--;
                }
            }
        }

        public override ObservableCollection<IModelBall> ReloadResub()
        {
            ModelBalls.Clear();
            foreach (IBall ball in logicApi.GetBallRepositoryList())
            {
                IModelBall modelBall = IModelBall.Instantiate(ball.Position_X, ball.Position_Y, ball.Radius);
                ModelBalls.Add(modelBall);
                ball.PropertyChanged += modelBall.Update!;
                Console.WriteLine(modelBall.Position_X.ToString());
                modelBall.DetermineColour(ball.Mass);
            }
            
            return ModelBalls;
        }

        public override void StartBallsMovement()
        {
            logicApi.StartBallsMovement();
        }

        public override void StopBallsMovement()
        {
            logicApi.StopBallsMovement();
        }
    }
}
