using ERPeducation.Common;
using ERPeducation.Common.Command;
using ERPeducation.Views;
using ERPeducation.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ERPeducation.ViewModels
{
    public class MainWindowViewModel : BaseDataForModules<TabItemMainWindowViewModel>
    {
        #region Свойства
        public string FullName { get; set; }
        public string Role { get; set; }
        #endregion
        #region Свойства контролов
        public bool[] IsEnabled { get; set; } = new bool[6] { false, false, false, false, false, false };
        private int width = 195;
        public int Width
        {
            get => width;
            set
            {
                width = value;
                if (width == 55) HorizontalAlignment = HorizontalAlignment.Center;
                else HorizontalAlignment = HorizontalAlignment.Right;
                OnPropertyChanged(nameof(Width));
            }
        }
        private HorizontalAlignment horizontalAlignment = HorizontalAlignment.Right;
        public HorizontalAlignment HorizontalAlignment
        {
            get => horizontalAlignment;
            private set
            {
                horizontalAlignment = value;
                OnPropertyChanged(nameof(HorizontalAlignment));
            }
        }
        #endregion
        #region Команды
        public ICommand CommandBurger { get; private set; }
        public ICommand CommandAddTabItem { get; private set; }
        public ICommand CommandNewTabItem { get; private set; }
        public ICommand CommandWindowClose {  get; private set; }
        #endregion

        public MainWindowViewModel(Action close, string role, string fullName)
        {
            DataForTabs = new string[] { "Ректор", "Деканат", "Учебный отдел", "Преподаватель", "Абитуриент", "Администрирование" };
            Close = close;
            FullName = fullName;
            Role = role;
            switch (role)
            {
                case "Admin":
                    for (int i = 0; i < IsEnabled.Length; i++) { IsEnabled[i] = true; }
                    break;
                case "Rector":
                    for (int i = 0; i < IsEnabled.Length; i++) { IsEnabled[i] = true; }
                    break;
                case "DeanRoom":
                    IsEnabled[1] = true;
                    break;
                case "TrainingDivision":
                    IsEnabled[2] = true;
                    break;
                case "Teacher":
                    IsEnabled[3] = true;
                    break;
                case "Enrollee":
                    IsEnabled[4] = true;
                    break;
                default:
                    MessageBox.Show("Ошибка доступа", "Сообщение");
                    //СДЕЛАТЬ ВЫХОД ИЗ ПРОГРАММЫ
                    break;
            }
            TabItem = new ObservableCollection<TabItemMainWindowViewModel>();
            TabItem.CollectionChanged += (object? sender, NotifyCollectionChangedEventArgs e) =>
            {
                if (e.OldItems != null) foreach (TabItemMainWindowViewModel item in e.OldItems) item.OnClose -= CloseTab;
                if (e.NewItems != null) foreach (TabItemMainWindowViewModel item in e.NewItems) item.OnClose += CloseTab;
            };
            CommandBurger = new MyCommand(WidthStackPanel);
            CommandAddTabItem = new MyCommand(AddTabItem);
            CommandNewTabItem = new MyCommand(NewTabItem);
            CommandWindowClose = new MyCommand(WindowClose);
        }

        #region Обработчики
        void WidthStackPanel(object contentButton)
        {
            if (Width >= 195)
            {
                Width = 55;
            }
            else Width = 195;
        }
        void AddTabItem(object contentButton)
        {
            bool ExistsTabItem = TabItem.Any(MyTabItem => MyTabItem.Title == contentButton.ToString());
            if (!ExistsTabItem && contentButton.ToString() == "Ректор")
            {
                TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleRector(new RectorViewModel())));
                return;
            }
            if (!ExistsTabItem && contentButton.ToString() == "Деканат")
            {
                TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleDeanRoom(new DeanRoomViewModel())));
                return;
            }
            if (!ExistsTabItem && contentButton.ToString() == "Учебный отдел")
            {
                TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleTrainingDivision(new TrainingDivisionViewModel())));
                return;
            }
            if (!ExistsTabItem && contentButton.ToString() == "Преподаватель")
            {
                TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleTeacher(new TeacherViewModel())));
                return;
            }
            if (!ExistsTabItem && contentButton.ToString() == "Абитуриент")
            {
                TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleEnrollee(new EnrolleeViewModel())));
                return;
            }
            if (!ExistsTabItem && contentButton.ToString() == "Администрирование")
            {
                TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleAdministration(new AdministrationViewModel())));
                return;
            }
        }
        void NewTabItem(object contentButton)
        {
            switch (contentButton.ToString())
            {
                case "Ректор":
                    TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleRector(new RectorViewModel())));
                    break;
                case "Деканат":
                    TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleDeanRoom(new DeanRoomViewModel())));
                    break;
                case "Учебный отдел":
                    TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleTrainingDivision(new TrainingDivisionViewModel())));
                    break;
                case "Преподаватель":
                    TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleTeacher(new TeacherViewModel())));
                    break;
                case "Абитуриент":
                    TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleEnrollee(new EnrolleeViewModel())));
                    break;
                case "Администрирование":
                    TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleAdministration(new AdministrationViewModel())));
                    break;
            }
            
        }
        void WindowClose(object contentButton) => Close();
        #endregion
        #region Методы
        void CloseTab(TabItemMainWindowViewModel tab) => TabItem.Remove(tab);
        public Action Close { get; set; }
        #endregion
    }
}
