using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel
{
    public class ViewMdl : INotifyPropertyChanged
    {
        private ModelApi modelApi;
        private bool swtch = true;
        private string ballz = string.Empty;

        public Commando CommandStart { get ; set; } = new Commando(DefaultAction, DefaultReady)!;
        public Commando CommandReset { get; set; } = new Commando(DefaultAction, DefaultReady)!;
        public ModelApi ModelApi { get => modelApi; set => modelApi = value; }
        public bool Swtch { get => swtch; set { swtch = value; NotifyPropertyChanged(); } }
        public string Ballz
        {
            get => ballz; set { ballz = value; NotifyPropertyChanged(); }
        }

        public ObservableCollection<IModelBall> ModelBalls => modelApi.ReloadResub();

        public event PropertyChangedEventHandler? PropertyChanged;

        public ViewMdl()
        {
            CommandStart = new Commando(Start, StartReady)!;
            CommandReset = new Commando(Reset, ResetReady)!;
            modelApi = ModelApi.Instantiate();
        }

        private void Start()
        {
            if (Ballz.Length > 0)
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
    
        
        private static void DefaultAction()
        {
            throw new System.Exception("ViewMdl contructor was not used!!!");
        }

        private static bool DefaultReady()
        {
            return false;
        }
    }
}
