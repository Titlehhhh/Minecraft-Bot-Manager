using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MinecraftBotManagerWPF.Commands
{
    public abstract class AsyncCommandBase : ICommand
    {
        private bool isexecut;

        public bool IsExecuting
        {
            get { return isexecut; }
            set
            {
                isexecut = value;
                OnCanExecuteChanged();
            }
        }


        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return !IsExecuting;
        }

        public async void Execute(object? parameter)
        {
            IsExecuting = true;

            await  ExecuteAsync(parameter);

            IsExecuting = false;
        }

        public abstract Task ExecuteAsync(object parameter);

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
