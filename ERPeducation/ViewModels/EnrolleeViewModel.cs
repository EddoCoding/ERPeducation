using ERPeducation.Common;
using ERPeducation.Views.ModuleEnrolle;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERPeducation.ViewModels
{
    public class EnrolleeViewModel : BaseDataForModules<TabItemEnrollee>
    {
        public EnrolleeViewModel() 
        {
            DataForTabs = new string[] { "Личная информация", "Контактная информация", "Образование", "Направление подготовки",
                                         "Поданные документы", "Результаты испытаний", "Заключить договор", "Печать"};
            TabItem = new ObservableCollection<TabItemEnrollee>();
            UserControl[] userControls = new UserControl[] 
            { 
                new EnrollePersonalInformationView()
            };
            for (int i = 0; i < DataForTabs.Length; i++)
            {
                TabItem.Add(new TabItemEnrollee(DataForTabs[i], userControls[0]));
            }
        }
    }
}
