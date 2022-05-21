using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DrawPictures.ViewModels.Base;

namespace DrawPictures.ViewModels
{
    internal class InkCanvasViewModel:ViewModelBase
    {
        #region inkCanvas : InkCanvas - Холст

        /// <summary>Холст</summary>
        private InkCanvas _inkCanvas;

        /// <summary>Холст</summary>
        public InkCanvas inkCanvas
        {
            get => _inkCanvas;
            set => Set(ref _inkCanvas, value);
        }
        #endregion
    }
}
