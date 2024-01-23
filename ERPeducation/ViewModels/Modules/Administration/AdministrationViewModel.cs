using ERPeducation.Common.Interface;
using ERPeducation.Views.Administration;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Controls;
using System.Windows.Media;

namespace ERPeducation.ViewModels.Modules.Administration
{
    public class AdministrationViewModel : ReactiveObject
    {
        #region Свойства
        bool isBoolUsers;
        public bool IsBoolUsers
        {
            get => isBoolUsers;
            set
            {
                this.RaiseAndSetIfChanged(ref isBoolUsers, value);
                if (value == true)
                {
                    BrushUsers = new SolidColorBrush(Color.FromRgb(245, 245, 245));
                }
                else BrushUsers = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
        }
        bool isBoolStruct;
        public bool IsBoolStruct
        {
            get => isBoolStruct;
            set
            {
                this.RaiseAndSetIfChanged(ref isBoolStruct, value);
                if (value == true)
                {
                    BrushStruct = new SolidColorBrush(Color.FromRgb(245,245,245));
                }
                else BrushStruct = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
        }
        [Reactive] public UserControl UserControlView { get; set; } 
        [Reactive] public UserControl UserStructView { get; set; } 

        [Reactive] public Brush BrushUsers { get; set; }
        [Reactive] public Brush BrushStruct { get; set; }
        #endregion


        MainWindowViewModel _mainWindowViewModel;

        IUserControlService _userControlService;

        public AdministrationViewModel(IUserControlService userControlService, MainWindowViewModel mainWindowViewModel)
        {
            _userControlService = userControlService;
            _mainWindowViewModel = mainWindowViewModel;

            UserControlView = new AdministrationUsersView();
            UserStructView = new AdministrationStructView();

            BrushUsers = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            BrushStruct = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }
    }
}
