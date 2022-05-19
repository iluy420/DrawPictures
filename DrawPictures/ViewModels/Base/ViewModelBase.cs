using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DrawPictures.ViewModels.Base
{
    internal abstract class ViewModelBase : INotifyPropertyChanged 
    {
        //интерфейс способный уведомлять о том что внутри нашего объекта изменилось какое-то свойство
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

    }
}
