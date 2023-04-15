using System;
using System.Windows.Input;

namespace ViewModel
{
    public class Commando : ICommand
    {
        private readonly Action method;
        private readonly Func<bool>? ready;
        public event EventHandler? CanExecuteChanged;

        public Commando(Action method, Func<bool>? ready = null)
        {
            if (method is null) throw new ArgumentNullException("method");

            this.method = method;
            this.ready = ready;
        }

        public bool CanExecute(object? parameter)
        {
            if(ready is null)
            {
                return false;
            }
            else
            {
                return ready();
            }
        }

        public void Execute(object? parameter)
        {
            method();
        }

        internal void NotifyCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
