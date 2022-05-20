using System;
using System.Windows.Input;

namespace TestLibrary
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract bool CanExecute(object parameter);//функция. Если false то коману выполнить нельзя, true можно

        public abstract void Execute(object parameter); //основная логика команды

    }
}
