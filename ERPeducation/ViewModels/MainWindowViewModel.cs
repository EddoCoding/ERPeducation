using ERPeducation.Common.Interface;
using ERPeducation.Common.Windows.AddUser;
using ERPeducation.Interface;
using ERPeducation.Models;
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
        #region Визуальные свойства
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

        public string FullName { get; set; }

        public bool RectorIsEnabled { get; set; }
        public bool DeanRoomIsEnabled { get; set; }
        public bool TrainingDivisionIsEnabled { get; set; }
        public bool TeacherIsEnabled { get; set; }
        public bool AdmissionCampaignIsEnabled { get; set; }
        public bool AdministrationIsEnabled { get; set; }
        public MainTabControl<MainTabItem> Data { get; set; }


        public ReactiveCommand<Unit, Unit> CloseCommand {  get; private set; }
        public ReactiveCommand<Unit, Unit> CommandBurger { get; private set; }
        public ReactiveCommand<string, Unit> CommandAddTabItem { get; private set; }
        public ReactiveCommand<string, Unit> CommandNewTabItem { get; private set; }


        IUserControlService _userControlService;

        public MainWindowViewModel(IUserControlService userControlService, Action close, UserViewModel user)
        {
            _userControlService = userControlService;
            FullName = user.FullName;

            Data = new MainTabControl<MainTabItem>()
            {
                TabItem = new ObservableCollection<MainTabItem>()
            };

            Data.TabItem.CollectionChanged += (object? sender, NotifyCollectionChangedEventArgs e) =>
            {
                if (e.OldItems != null) foreach (MainTabItem item in e.OldItems) item.OnClose -= CloseTab;
                if (e.NewItems != null) foreach (MainTabItem item in e.NewItems) item.OnClose += CloseTab;
            };

            CloseCommand = ReactiveCommand.Create(close);
            InitializingCommands();
        }

        void InitializingCommands()
        {
            CommandBurger = ReactiveCommand.Create(() =>
            {
                if (Width >= 195) { Width = 55; }
                else Width = 195;
            });
            CommandAddTabItem = ReactiveCommand.Create<string>(parameter =>
            {
                bool ExistsTabItem = Data.TabItem.Any(MyTabItem => MyTabItem.Title == parameter);
                if (!ExistsTabItem && parameter == "Приёмная кампания")
                {
                    Data.TabItem.Add(new MainTabItem(parameter, _userControlService.GetModuleAdmissionCampaign(Data)));
                    return;
                }
                if (!ExistsTabItem && parameter == "Администрирование")
                {
                    Data.TabItem.Add(new MainTabItem(parameter, _userControlService.GetModuleAdministration()));
                    return;
                }
            });
            CommandNewTabItem = ReactiveCommand.Create<string>(parameter =>
            {
                switch (parameter)
                {
                    case "Приёмная кампания":
                        Data.TabItem.Add(new MainTabItem(parameter, _userControlService.GetModuleAdmissionCampaign(Data)));
                        break;
                    case "Администрирование":
                        Data.TabItem.Add(new MainTabItem(parameter, _userControlService.GetModuleAdministration()));
                        break;
                }
            });
        }
        void CloseTab(MainTabItem tab) => Data.TabItem.Remove(tab);
    }
}
