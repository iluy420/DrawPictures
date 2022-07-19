using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;
using DrawPictures.Infrastructure.Commands;
using DrawPictures.ViewModels.Base;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MessageBox = System.Windows.MessageBox;
using TabItem = System.Windows.Controls.TabItem;
using DialogResult = System.Windows.Forms.DialogResult;
using TextBox = System.Windows.Controls.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


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

        #region drawingAttributes : DrawingAttributes - Перо

        /// <summary>Перо</summary>
        private double _drawingAttributes;

        /// <summary>Перо</summary>
        public double drawingAttributes
        {
            get => _drawingAttributes;
            set
            {
                if (value > 50)//Если введенное значение добльше 50
                {
                    value = 50;
                }
                Set(ref _drawingAttributes, Math.Round(value, 2));
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
            set => Set(ref _EditingMode, value);

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

        #region OnSelectionTabChanged - При смене вкладки

        public void OnSelectionTabChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var tab in _Tabs)
            {
                if (tab.IsSelected)
                    CurrentWindowSetting(tab);
            }
        }

        #endregion

        #region OndrawingAttributesChanged - При изменении атрибутов размера пера

        public void OndrawingAttributesChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            foreach (var tab in _Tabs)
            {
                if (!tab.IsSelected || !(tab.Content is Frame)) continue;

                 Frame currentFrame = (Frame)tab.Content;
                 Picture picture = (Picture)currentFrame.Content;
                 PictureViewModel vm = (PictureViewModel)picture.DataContext;
                 vm.drawingAttributes.Width = _drawingAttributes;
                 vm.drawingAttributes.Height = _drawingAttributes;
            }
        }

        //обработка ввода
        public void UIElement_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
           if (!Char.IsDigit(e.Text, 0))
           {
               if (e.Text != "." ||((TextBox)sender).Text.Contains("."))
               {
                   e.Handled = true;
               }
           }
        }

        //ввод на enter
        #endregion

        #region CurrentWindowSetting - Настройка текущего окна

        private void CurrentWindowSetting(TabItem tab)
        {
            if (tab.Content is Frame)
            {
                Frame currentFrame = (Frame)tab.Content;
                Picture picture = (Picture)currentFrame.Content;
                PictureViewModel vm = (PictureViewModel)picture.DataContext;
                //изменение слайдера
                drawingAttributes = vm.drawingAttributes.Width;
                // изменение режима записи
                vm.EditingMode = EditingMode;
            }
        }

        #endregion

        #endregion


        #region Команды

        #region EraseSelectionCommand - Выбор режима стерки

        public ICommand EraseSelectionCommand { get; }

        private void OnEraseSelectionCommandExecute(object p)
        {
            EditingMode = InkCanvasEditingMode.EraseByStroke;
        }

        private bool CanEraseSelectionCommandExecuted(object p) => true;

        #endregion

        #region InkSelectionCommand - Выбор режима рисования

        public ICommand InkSelectionCommand { get; }

        private void OnInkSelectionCommandExecute(object p)
        {
            EditingMode = InkCanvasEditingMode.Ink;
        }

        private bool CanInkSelectionCommandExecuted(object p) => true;

        #endregion

        #region ColorSelectionCommand - Выбор цвета
        public ICommand ColorSelectionCommand { get; }

        private void OnColorSelectionCommandExecute(object p)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() != DialogResult.OK) return;
            foreach (var tab in _Tabs)
            {
                if (!tab.IsSelected || !(tab.Content is Frame)) continue;

                Frame currentFrame = (Frame)tab.Content;
                Picture picture = (Picture)currentFrame.Content;
                PictureViewModel vm = (PictureViewModel)picture.DataContext;
                vm.drawingAttributes.Color = System.Windows.Media.Color.FromArgb(colorDialog.Color.A,
                    colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
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
            EraseSelectionCommand = new LambdaCommand(OnEraseSelectionCommandExecute, CanEraseSelectionCommandExecuted);
            InkSelectionCommand = new LambdaCommand(OnInkSelectionCommandExecute, CanInkSelectionCommandExecuted);
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
