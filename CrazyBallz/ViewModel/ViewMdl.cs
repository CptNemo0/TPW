using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ViewMdl : INotifyPropertyChanged
    {
        private Commando commandStart;
        private Commando commandReset;
        private ModelApi modelApi;
        private bool swtch = true;
        private string ballz = string.Empty;

        public Commando CommandStart { get => commandStart; set => commandStart = value; }
        public Commando CommandReset { get => commandReset; set => commandReset = value; }
        public ModelApi ModelApi { get => modelApi; set => modelApi = value; }
        public bool Swtch { get => swtch; set { swtch = value; NotifyPropertyChanged(); } }
        public string Ballz { get => ballz; set { ballz = value; NotifyPropertyChanged(); }
}
        public ObservableCollection<IModelBall> ModelBalls => modelApi.ReloadResub();

        public event PropertyChangedEventHandler? PropertyChanged;

        public ViewMdl() : this(ModelApi.Instantiate())
        {
        }

        public ViewMdl(ModelApi modelApi) 
        {
            CommandStart = new Commando(Start, StartReady);
            CommandReset = new Commando(Reset, ResetReady);
            this.modelApi = modelApi;
        }

        private void Start()
        {
            if(Ballz.Length > 0)
            {
                int amount = int.Parse(Ballz);
                if (amount > 0)
                {
                    modelApi.NewRandomBalls(amount);
                    NotifyPropertyChanged(nameof(ModelBalls));
                    modelApi.StartBallsMovement();
                    SwitchSwtch();
                }
            }
        }


        private void Reset() 
        {
            modelApi.StopBallsMovement();
            modelApi.RemoveAllBalls();
            NotifyPropertyChanged(nameof(ModelBalls));
            SwitchSwtch();
        }

        private bool StartReady()
        {
            return Swtch;
        }

        private bool ResetReady()
        {
            return !Swtch;
        }

        private void SwitchSwtch()
        {
            Swtch = !Swtch;
            CommandStart.NotifyCanExecuteChanged();
            CommandReset.NotifyCanExecuteChanged();

        }

        private void NotifyPropertyChanged([CallerMemberName] string? propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
