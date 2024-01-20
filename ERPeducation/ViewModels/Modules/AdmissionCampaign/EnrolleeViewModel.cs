using ERPeducation.Common;
using ERPeducation.Common.Interface;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class EnrolleeViewModel
    {   
        public BaseDataForModules<TabItemEnrollee> Data { get; set; }

        IUserControlService _userControlService;

        public EnrolleeViewModel(IUserControlService userControlService)
        {
            _userControlService = userControlService;

            Data = new BaseDataForModules<TabItemEnrollee>()
            {
                DataForTabs = new string[] { "Личная информация", "Контактная информация", "Образование", "Направление подготовки",
                                         "Поданные документы", "Результаты испытаний", "Заключить договор", "Дело", "Печать"},
                TabItem = new ObservableCollection<TabItemEnrollee>()
            };

            for (int i = 0; i < Data.DataForTabs.Length; i++)
            {
                Data.TabItem.Add(new TabItemEnrollee(Data.DataForTabs[i],
                    _userControlService.GetUserControlForModuleEnrollee(Data.DataForTabs[i])));
            }
            //Перебор, добавление вкладок с наименованием из массива строк и контентом для вкладок из Сервиса
        }
    }
}
