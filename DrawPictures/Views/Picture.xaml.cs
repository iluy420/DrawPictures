using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrawPictures
{
    public partial class Picture : Page
    {
        public static RoutedCommand MyCommand = new RoutedCommand();
        public static RoutedCommand MyCommand1 = new RoutedCommand();
        public System.Windows.Ink.StrokeCollection _added;
        public static System.Windows.Ink.StrokeCollection _removed;
        //private bool handle = true;
        public Picture()
        {
            InitializeComponent();
            MyCommand.InputGestures.Add(new KeyGesture(Key.Z, ModifierKeys.Control));
            MyCommand1.InputGestures.Add(new KeyGesture(Key.Y, ModifierKeys.Control));
            //ink.Strokes.StrokesChanged += Strokes_StrokesChanged;
        }
        //private void Strokes_StrokesChanged(object sender, System.Windows.Ink.StrokeCollectionChangedEventArgs e)
        //{
        //    //if (handle)
        //    //{
        //    if (_removed == null)
        //    {
        //        _removed = e.Removed;

        //    }
        //    else
        //    {
        //        _removed.Add(e.Removed);
        //    }

        //    //}


        //    //}
        //}
        //private void Undo_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ink.Strokes.Count > 0)
        //    {
        //        int gg = ink.Strokes.Count - 1;
        //        Stroke strokes = ink.Strokes[gg].Clone();
        //        //_removed.Add(strokes);
        //        ink.Strokes.RemoveAt(ink.Strokes.Count - 1);
        //    }
        //}
        //private void Redo_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ink.Strokes.Count > 0)
        //    {
        //        _removed.Add(ink.Strokes[ink.Strokes.Count - 1]);
        //        ink.Strokes.Add(_removed);

        //    }
        //}

        private void Undo(object sender, RoutedEventArgs e)
        {
            //handle = false;
            //ink.Strokes.Remove(_added);
            //ink.Strokes.Add(_removed);
            //handle = true;
        }

        private void Redo(object sender, RoutedEventArgs e)
        {
            //handle = false;
            //ink.Strokes.Add(_added);
            //ink.Strokes.Remove(_removed);
            //handle = true;
        }
        //public InkCanvas Convas_Return()
        //{
        //    return ink;
        //}

        private void PasteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Image image = new Image();
            //image.Source = new BitmapImage(new Uri("Images/delete.png", UriKind.Relative));

            //ink.Children.Add(image);
        }
    }
}
