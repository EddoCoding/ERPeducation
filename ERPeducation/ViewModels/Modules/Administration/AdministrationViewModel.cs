using ERPeducation.Common.Interface;
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


        //Раскрываюющие списки в Администрировании
        [Reactive] public UserControl UserControlUserView { get; set; } 
        [Reactive] public UserControl UserControlStructView { get; set; } 


        [Reactive] public Brush BrushUsers { get; set; }
        [Reactive] public Brush BrushStruct { get; set; }
        #endregion


        IUserControlService _userControlService;

        public AdministrationViewModel(IUserControlService userControlService)
        {
            _userControlService = userControlService;

            UserControlUserView = _userControlService.GetUserControlForAdministrationView();

            BrushUsers = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            BrushStruct = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }
    }
}
