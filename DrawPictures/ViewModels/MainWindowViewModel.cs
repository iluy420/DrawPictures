using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DrawPictures.ViewModels.Base;

namespace DrawPictures.ViewModels
{
    internal class MainWindowViewModel: ViewModelBase
    {
        #region Заголовок окна

        private string _Title = "Draw pictures";
            /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
            //set
            //{
            //    if (Equals(_Title, value)) return;
            //    _Title = value;
            //    OnPropertyChanged();
            //}
            //или
            //set
            //{
            //    Set(ref _Title, value);
            //}

        }

        #endregion
        //#region Дата и время

        //private string _Title = "Draw pictures";
        ///// <summary>Заголовок окна</summary>
        //public string Title
        //{
        //    get => _Title;
        //    set => Set(ref _Title, value);
        //    //set
        //    //{
        //    //    if (Equals(_Title, value)) return;
        //    //    _Title = value;
        //    //    OnPropertyChanged();
        //    //}
        //    //или
        //    //set
        //    //{
        //    //    Set(ref _Title, value);
        //    //}

        //}

        //#endregion
    }
}
