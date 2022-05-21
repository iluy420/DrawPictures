using System.Windows;
using DrawPictures.Infrastructure.Commands.Base;

namespace DrawPictures.Infrastructure.Commands
{
    internal class CloseApplicationCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
