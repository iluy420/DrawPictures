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
using System.Windows.Threading;
using System.Windows.Forms;

namespace DrawPictures
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Frame newframe = new Frame();
            //newframe.Content = new Picture();
            //TabControlFrame.Items.Add(newframe);
        }
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (System.Windows.MessageBox.Show("Вы уверены?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void MainFrame_OnNavigeted(object sender, NavigationEventArgs e)
        {
            //if (!(e.Content is Page page)) return;
            //Title = $"ProjectByMarkovAndLaytifov - {page.Title}";

            //if (page is Pages.Login) Back.Visibility = Visibility.Hidden;
            //else Back.Visibility = Visibility.Visible;

            //if (page is Pages.Calculator || page is Pages.Login) Calculator.Visibility = Visibility.Hidden;
            //else Calculator.Visibility = Visibility.Visible;

            //if (page is Pages.Calculator)
            //{

            //    // определяем путь к файлу ресурсов
            //    var uri = new Uri("Dictionaries/DictionaryCalc.xaml", UriKind.Relative);
            //    // загружаем словарь ресурсов
            //    ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            //    // очищаем коллекцию ресурсов приложения
            //    Application.Current.Resources.Clear();
            //    // добавляем загруженный словарь ресурсов
            //    Application.Current.Resources.MergedDictionaries.Add(resourceDict);

            //}
            //else
            //{
            //    // определяем путь к файлу ресурсов
            //    var uri = new Uri("Dictionaries/Dictionary.xaml", UriKind.Relative);
            //    // загружаем словарь ресурсов
            //    ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            //    // очищаем коллекцию ресурсов приложения
            //    Application.Current.Resources.Clear();
            //    // добавляем загруженный словарь ресурсов
            //    Application.Current.Resources.MergedDictionaries.Add(resourceDict);

            //}
        }


        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    ColorDialog colorDialog = new ColorDialog();
        //    if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        Frame currentFrame = (Frame)TabControlFrame.SelectedContent;
        //        Picture picture = (Picture)currentFrame.Content;
        //        picture.Convas_Return().DefaultDrawingAttributes.Color = Color.FromArgb(colorDialog.Color.A,
        //        colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
        //    }
        //}
        //private void AddPictureButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Frame newframe = new Frame();
        //    newframe.Content = new Picture();
        //    TabControlFrame.Items.Add(newframe);
        //    TabControlFrame.SelectedIndex = TabControlFrame.Items.Count-1; 
        //}
        //private void Del_Click(object sender, RoutedEventArgs e)
        //{
        //    TabControlFrame.Items.Remove(TabControlFrame);
        //}
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //((Slider)sender).SelectionEnd = e.NewValue;
            //Frame currentFrame = (Frame)TabControlFrame.SelectedContent;
            //if(currentFrame != null) {
            //    Picture picture = (Picture)currentFrame.Content;
            //    picture.Convas_Return().DefaultDrawingAttributes.Height = e.NewValue;
            //    picture.Convas_Return().DefaultDrawingAttributes.Width = e.NewValue;
            //}
            
        }
    }
}
