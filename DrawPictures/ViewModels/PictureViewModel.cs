using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using DrawPictures.ViewModels.Base;

namespace DrawPictures.ViewModels
{
    internal class PictureViewModel : ViewModelBase
    {
        #region Свойства

        #region CurrentInkCanvas : InkCanvas - Текущий InkConvas

        /// <summary>Текущий InkConvas</summary>
        private InkCanvas _CurrentInkCanvas = new InkCanvas();

        /// <summary>Текущий InkConvas</summary>
        public InkCanvas CurrentInkCanvas
        {
            get => _CurrentInkCanvas;
            set => Set(ref _CurrentInkCanvas, value);
        }
        #endregion

        #region drawingAttributes : DrawingAttributes - Перо

        /// <summary>Перо</summary>
        private DrawingAttributes _drawingAttributes = new InkCanvas().DefaultDrawingAttributes.Clone();

        /// <summary>Перо</summary>
        public DrawingAttributes drawingAttributes
        {
            get => _drawingAttributes;
            set
            {
                Set(ref _drawingAttributes, value);
                //запись значения пера
                _CurrentInkCanvas.DefaultDrawingAttributes = _drawingAttributes;
            }

        }
        #endregion

        #region EditingMode : InkCanvasEditingMode - Режим редактирования inkconvas

        /// <summary>Режим редактирования inkconvas</summary>
        private InkCanvasEditingMode _EditingMode = new InkCanvas().EditingMode;

        /// <summary>Режим редактирования inkconvas</summary>
        public InkCanvasEditingMode EditingMode
        {
            get => _EditingMode;
            set
            {
                Set(ref _EditingMode, value);
                //запись значения режима редактирования
                _CurrentInkCanvas.EditingMode = _EditingMode;
            }

        }
        #endregion

        #endregion

    }
}
