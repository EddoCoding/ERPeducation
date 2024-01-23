using System;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.FieldOfStudy
{
    public class FieldsViewModel
    {
        public string[] FormOfStudy { get; set; } = { "Очная", "Очно-Заочная", "Заочная" }; //Данные добавляются из Json файлов т.е. нужен  
                                                                                            //метод инициализации через десериализацию
        public string ValueComboBoxForm { get; set; }

        public string[] FiledsOfStudy { get; set; } = { "Направление1", "Направление2", "Направление3" }; //Данные добавляются из Json файлов т.е. нужен  
                                                                                                          //метод инициализации через десериализацию
        public string ValueComboBoxField { get; set; }

        public FieldsViewModel(Action closeWindow) 
        { 
        
        }
    }
}