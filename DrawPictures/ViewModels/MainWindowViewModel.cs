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

        #region Закрытие окна

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
        }

        #endregion


        #endregion

        #region Команды

        #region CloseApplicationCommand - Закрытие окна

        //public ICommand CloseApplicationCommand { get; }

        //private void OnCloseApplicationCommandExecute(object p)
        //{
        //    if (System.Windows.MessageBox.Show("Вы уверены?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        //    {
        //        System.Windows.Application.Current.Shutdown();
        //    }
        //}

        //private bool CanCloseApplicationCommandExecuted(object p) => true;

        #endregion

        #region ColorSelectionCommand - Выбор цвета
        public ICommand ColorSelectionCommand { get; }

        private void OnColorSelectionCommandExecute(object p)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                //Frame currentFrame = (Frame)TabControlFrame.SelectedContent;
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
            _Tabs[_Tabs.Count - 1].IsSelected = true;
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

            //CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecute, CanCloseApplicationCommandExecuted);
            ColorSelectionCommand = new LambdaCommand(OnColorSelectionCommandExecute, CanColorSelectionCommandExecuted);
            AddTabCommand = new LambdaCommand(OnAddTabCommandExecute, CanAddTabCommandExecuted);
            DelTabCommand = new LambdaCommand(OnDelTabCommandExecute, CanDelTabCommandExecuted);


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

            #region Привязка события закрытия приложения

            if (Application.Current.MainWindow != null)
                Application.Current.MainWindow.Closing += new CancelEventHandler(OnWindowClosing);

            #endregion

        }
    }
}
