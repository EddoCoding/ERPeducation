using ERPeducation.Common;
using ERPeducation.Common.Interface.DialogPersonal;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class EnrolleeViewModel
    {   
        IDialogService _dialogService;

        public BaseDataForModules<TabItemEnrollee> Data { get; set; }
        public EnrolleeViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            Data = new BaseDataForModules<TabItemEnrollee>()
            {
                DataForTabs = new string[] { "Личная информация", "Контактная информация", "Образование", "Направление подготовки",
                                         "Поданные документы", "Результаты испытаний", "Заключить договор", "Дело", "Печать"},
                TabItem = new ObservableCollection<TabItemEnrollee>()
            };

            for (int i = 0; i < Data.DataForTabs.Length; i++)
            {
                Data.TabItem.Add(new TabItemEnrollee(Data.DataForTabs[i],
                    _dialogService.GetUserControlForModuleEnrollee(Data.DataForTabs[i])));
            }
            //Перебор, добавление вкладок с наименованием из массива строк и контентом для вкладок из Сервиса
        }
    }
}
