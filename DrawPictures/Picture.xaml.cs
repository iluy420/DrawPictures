using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrawPictures
{
    public partial class Picture : Page
    {
        public Picture()
        {
            InitializeComponent();
        }
        public InkCanvas Convas_Return()
        {
            return ink;
        }

        private void PasteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri("Images/delete.png", UriKind.Relative));

            ink.Children.Add(image);
        }
    }
}
