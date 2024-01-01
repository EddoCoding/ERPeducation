using ERPeducation.Common;
using ERPeducation.Views.ModuleEnrolle;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class EnrolleeViewModel
    {   
        public BaseDataForModules<TabItemEnrollee> Data { get; set; }

        public EnrolleeViewModel()
        {
            Data = new BaseDataForModules<TabItemEnrollee>()
            {
                DataForTabs = new string[] { "Личная информация", "Контактная информация", "Образование", "Направление подготовки",
                                         "Поданные документы", "Результаты испытаний", "Заключить договор", "Дело", "Печать"},
                TabItem = new ObservableCollection<TabItemEnrollee>()
            };

            UserControl[] userControls = new UserControl[]
            {
                new EnrollePersonalInformationView(new EnrollePersonalInformationViewModel())
            };
            //Массив Views с передачей в них ViewModels

            //Data.TabItem.Add(new TabItemEnrollee(Data.DataForTabs[0], userControls[0]));
            //Data.TabItem.Add(new TabItemEnrollee(Data.DataForTabs[1], userControls[0]));

            for (int i = 0; i < Data.DataForTabs.Length; i++)
            {
                Data.TabItem.Add(new TabItemEnrollee(Data.DataForTabs[i], userControls[0]));
            } 
            //Перебор, добавление вкладок с наименованием из массива строк и контентом для вкладок из массива Views
        }
    }
}
