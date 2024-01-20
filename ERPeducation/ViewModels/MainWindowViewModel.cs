﻿using ERPeducation.Common;
using ERPeducation.Common.Interface;
using ERPeducation.Interface;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive;
using System.Windows;

namespace ERPeducation.ViewModels
{
    public class MainWindowViewModel : INPC
    {

        #region Свойства
        public string FullName { get; set; }
        public string Role { get; set; }
        public BaseDataForModules<TabItemMainWindowViewModel> Data { get; set; }
        #endregion
        #region Визуальные свойства
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
        public ReactiveCommand<Unit, Unit> CloseCommand {  get; set; }
        public ReactiveCommand<object, Unit> CommandBurger { get; private set; }
        public ReactiveCommand<object, Unit> CommandAddTabItem { get; private set; }
        public ReactiveCommand<object, Unit> CommandNewTabItem { get; private set; }
        public ReactiveCommand<Unit, Unit> CommandWindowClose {  get; private set; }
        #endregion

        IUserControlService _userControlService;
        public MainWindowViewModel(IUserControlService userControlService, Action close, string role, string fullName)
        {
            _userControlService = userControlService;

            FullName = fullName;
            Role = role;

            Data = new BaseDataForModules<TabItemMainWindowViewModel>()
            {
                TabItem = new ObservableCollection<TabItemMainWindowViewModel>(),
                DataForTabs = new string[] { "Ректор", "Деканат", "Учебный отдел", "Преподаватель", "Приёмная кампания", "Администрирование" }
                //МОДУЛЬ - БИБЛИОТЕКА +ДОБАВИТЬ ПОТОМ!!!!!!
                //МОДУЛЬ - ДОП. ОБРАЗОВАНИЕ +ДОБАВИТЬ ПОТОМ!!!!!!
                //МОДУЛЬ - ДОПОЛНИТЕЛЬНЫЙ(БУХГАЛТЕРИЯ, КАДРЫ, ФАКУЛЬТЕТ) +ДОБАВИТЬ ПОТОМ!!!!!!
            };

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
            } //ЧТО-ТО ДОБАВИТЬ НАДО БЫЛО !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            Data.TabItem.CollectionChanged += (object? sender, NotifyCollectionChangedEventArgs e) =>
            {
                if (e.OldItems != null) foreach (TabItemMainWindowViewModel item in e.OldItems) item.OnClose -= CloseTab;
                if (e.NewItems != null) foreach (TabItemMainWindowViewModel item in e.NewItems) item.OnClose += CloseTab;
            };

            CommandBurger = ReactiveCommand.Create<object>(WidthStackPanel);
            CommandAddTabItem = ReactiveCommand.Create<object>(AddTabItem);
            CommandNewTabItem = ReactiveCommand.Create<object>(NewTabItem);
            CloseCommand = ReactiveCommand.Create(close);
        }

        #region Обработчики
        void WidthStackPanel(object contentButton)
        {
            if (Width >= 195) { Width = 55; }
            else Width = 195;
        }
        void AddTabItem(object contentButton)
        {
            bool ExistsTabItem = Data.TabItem.Any(MyTabItem => MyTabItem.Title == contentButton.ToString());
            //if (!ExistsTabItem && contentButton.ToString() == "Ректор")
            //{
            //    Data.TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleRector(new RectorViewModel())));
            //    return;
            //}
            //if (!ExistsTabItem && contentButton.ToString() == "Деканат")
            //{
            //    Data.TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleDeanRoom(new DeanRoomViewModel())));
            //    return;
            //}
            //if (!ExistsTabItem && contentButton.ToString() == "Учебный отдел")
            //{
            //    Data.TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleTrainingDivision(new TrainingDivisionViewModel())));
            //    return;
            //}
            //if (!ExistsTabItem && contentButton.ToString() == "Преподаватель")
            //{
            //    Data.TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleTeacher(new TeacherViewModel())));
            //    return;
            //}
            if (!ExistsTabItem && contentButton.ToString() == "Приёмная кампания")
            {
                Data.TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(),
                    _userControlService.GetUserControl(contentButton.ToString(), this)));
                return;
            }
            //if (!ExistsTabItem && contentButton.ToString() == "Администрирование")
            //{
            //    Data.TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleAdministration(new AdministrationViewModel())));
            //    return;
            //}
        }
        void NewTabItem(object contentButton)
        {
            switch (contentButton.ToString())
            {
                //case "Ректор":
                //    Data.TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleRector(new RectorViewModel())));
                //    break;
                //case "Деканат":
                //    Data.TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleDeanRoom(new DeanRoomViewModel())));
                //    break;
                //case "Учебный отдел":
                //    Data.TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleTrainingDivision(new TrainingDivisionViewModel())));
                //    break;
                //case "Преподаватель":
                //    Data.TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleTeacher(new TeacherViewModel())));
                //    break;
                case "Приёмная кампания":
                    Data.TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(),
                    _userControlService.GetUserControl(contentButton.ToString(), this)));
                    break;
                //case "Администрирование":
                //    Data.TabItem.Add(new TabItemMainWindowViewModel(contentButton.ToString(), new ModuleAdministration(new AdministrationViewModel())));
                //    break;
            }
        }
        #endregion
        #region Методы
        void CloseTab(TabItemMainWindowViewModel tab) => Data.TabItem.Remove(tab);
        #endregion
    }
}
