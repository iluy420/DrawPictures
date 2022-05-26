using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DrawPictures.Infrastructure.Commands.Base
{
    internal abstract class CommandBase : ICommand
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
