using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;
using DrawPictures.Infrastructure.Commands;
using DrawPictures.ViewModels.Base;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;
using TabItem = System.Windows.Controls.TabItem;
using DialogResult = System.Windows.Forms.DialogResult;
using static DrawPictures.ViewModels.PictureViewModel;
using System.Windows.Ink;

namespace DrawPictures.ViewModels
{
    internal class MainWindowViewModel:ViewModelBase
    {
        #region Свойства

        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Draw pictures";
        
        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion

        #region CurrentDataTime : string - Текущая дата и время

        /// <summary>Текущая дата и время</summary>
        private string _CurrentDataTime;

        /// <summary>Текущая дата и время</summary>
        public string CurrentDataTime
        {
            get => _CurrentDataTime;
            set => Set(ref _CurrentDataTime, value);
        }
        #endregion

        #region Tabs : ObservableCollection<TabItem> - Коллекция вкладок

        /// <summary>Коллекция вкладок</summary>
        private ObservableCollection<TabItem> _Tabs;

        /// <summary>Коллекция вкладок</summary>
        public ObservableCollection<TabItem> Tabs
        {
            get => _Tabs;
            set => Set(ref _Tabs, value);
        }
        #endregion

        #region TabsCurrent : TabItem - Выбранная вкладка

        /// <summary>Выбранная вкладка</summary>
        private TabItem _TabsCurrent;

        /// <summary>Выбранная вкладка</summary>
        public TabItem TabsCurrent
        {
            get => _TabsCurrent;
            set => Set(ref _TabsCurrent, value);
        }
        #endregion

        #endregion

        #region Методы

        #region OnWindowClosing - При закрытии окна

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region drawingAttributes : DrawingAttributes - Перо

        /// <summary>Перо</summary>
        private double _drawingAttributes;

        /// <summary>Перо</summary>
        public double drawingAttributes
        {
            get => _drawingAttributes;
            set
            {
                Set(ref _drawingAttributes, value);
                //запись значения пера
            }

        }
        #endregion
        #endregion


        public void OndrawingAttributesChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            foreach (var tab in _Tabs)
            {
                if (tab.IsSelected)
                {
                    if (tab.Content is Frame)
                    {
                        Frame currentFrame = (Frame)tab.Content;
                        Picture picture = (Picture)currentFrame.Content;
                        PictureViewModel vm = (PictureViewModel)picture.DataContext;
                        vm.drawingAttributes.Width = _drawingAttributes;
                        vm.drawingAttributes.Height = _drawingAttributes;
                    }
                }



            }
        }
        
        #region OnSelectionTabChanged - При выборе элемента
        public void OnSelectionTabChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var tab in _Tabs)
            {
                if (tab.IsSelected)
                    gg(tab);


            }
        }
        private void gg(TabItem tab)
        {
            if (tab.Content is Frame)
            {
                Frame currentFrame = (Frame)tab.Content;
                Picture picture = (Picture)currentFrame.Content;
                PictureViewModel vm = (PictureViewModel)picture.DataContext;
                _drawingAttributes = vm.drawingAttributes.Width;
            }
            
            //picture.Convas_Return().DefaultDrawingAttributes.Color = Color.FromArgb(colorDialog.Color.A,
            //colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
        }

        #endregion
        //#region SelectionTabChanged - выбор  вкладки
        //public ICommand SelectionTabChanged { get; }

        //private void OnSelectionTabChanged(object p)
        //{
        //    foreach (var tab in _Tabs)
        //    {
        //        if (tab.IsSelected)
        //            gg(tab);


        //    }
        //}

        //private bool CanSelectionTabChangedExecuted(object p) => true;


        //private void gg(TabItem tab)
        //{
        //    Picture picture = (Picture)tab.Content;
        //    //picture.Convas_Return().DefaultDrawingAttributes.Color = Color.FromArgb(colorDialog.Color.A,
        //    //colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
        //}
        //#endregion

        #region Команды

        #region ColorSelectionCommand - Выбор цвета
        public ICommand ColorSelectionCommand { get; }

        private void OnColorSelectionCommandExecute(object p)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                
                //Frame currentFrame = (Frame)c;
                //Picture picture = (Picture)currentFrame.Content;
                //picture.Convas_Return().DefaultDrawingAttributes.Color = Color.FromArgb(colorDialog.Color.A,
                //    colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            }
        }

        private bool CanColorSelectionCommandExecuted(object p) => true;

        #endregion

        #region AddTabCommand - Добавление вкладки
        public ICommand AddTabCommand { get; }

        private void OnAddTabCommandExecute(object p)
        {
            _Tabs.Add(new TabItem { Content = new Frame { Content = new Picture() }});
            TabsCurrent = _Tabs[_Tabs.Count - 1];
        }

        private bool CanAddTabCommandExecuted(object p) => true;
        #endregion

        #region DelTabCommand - Удаление вкладки
        public ICommand DelTabCommand { get; }

        private void OnDelTabCommandExecute(object p)
        {
            try
            {
                _Tabs.Remove((TabItem)p);
            }
            catch
            {
                System.Windows.MessageBox.Show("вкладки закончились! успокойся уже!");
            }
        }

        private bool CanDelTabCommandExecuted(object p) => true;
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            ColorSelectionCommand = new LambdaCommand(OnColorSelectionCommandExecute, CanColorSelectionCommandExecuted);
            AddTabCommand = new LambdaCommand(OnAddTabCommandExecute, CanAddTabCommandExecuted);
            DelTabCommand = new LambdaCommand(OnDelTabCommandExecute, CanDelTabCommandExecuted);
            //SelectionTabChanged = new LambdaCommand(OnSelectionTabChanged, CanSelectionTabChangedExecuted);

            #endregion

            #region Установка даты и времени

            DispatcherTimer _DateTimeNow = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _DateTimeNow.Tick += (object sender, EventArgs e) =>
            {
                CurrentDataTime = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
            };
            _DateTimeNow.Start();

            #endregion

            #region Установка первой вкладки
            _Tabs = new ObservableCollection<TabItem> {new TabItem
            {
                Header = "gg"
                ,Content = "Добавить кладку"
            }};
            #endregion

        }
    }
}
