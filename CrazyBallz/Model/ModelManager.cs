using Logic;
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

        public override void CreateBallAtRandomCoordinates()
        {
            logicApi.CreateBallAtRandomCoordinates();
        }

        public override void NewRandomBalls(int n)
        {
            for(int i = 0; i < n; i++)
            {
                logicApi.CreateBallAtRandomCoordinates();
            }
        }

        public override ObservableCollection<IModelBall> ReloadResub()
        {
            ModelBalls.Clear();
            foreach (IBall ball in logicApi.GetBallRepositoryList())
            {
                IModelBall modelBall = IModelBall.Instantiate(ball.Position_X, ball.Position_Y, ball.Radius);
                ModelBalls.Add(modelBall);
                modelBall.DetermineColour(ball.Mass);
                ball.PropertyChanged += modelBall.Update!;
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
