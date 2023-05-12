using Logic;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class ModelApi
    {
        public static ModelApi Instantiate()
        {
            return new ModelManager(LogicApi.Instantiate(1400, 700));
        }
        public abstract void StartBallsMovement();
        public abstract void StopBallsMovement();
        public abstract ObservableCollection<IModelBall> ReloadResub();
        public abstract bool CreateBallAtRandomCoordinates();
        public abstract void NewRandomBalls(int n);
        public abstract void RemoveAllBalls();
    }
}
