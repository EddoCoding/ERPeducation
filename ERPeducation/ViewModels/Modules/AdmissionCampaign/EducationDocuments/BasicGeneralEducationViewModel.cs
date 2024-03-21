using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.EducationDocuments
{
    public class BasicGeneralEducationViewModel : EducationDocumentBase
    {
        [Reactive] public string CodeSeriesNumber { get; set; } = string.Empty;

        //КОНСТРУКТОР ДЛЯ ИЗМЕНЕНИЯ ОБЪЕКТА
        //ОСНОВНОЙ КОНСТРУКТОР ДЛЯ НОВОГО ДОКУМЕНТА
        public BasicGeneralEducationViewModel(ObservableCollection<EducationDocumentBase> education, Action closeWindow) 
        {
            TypeEducation = "Основное общее образование";

            //OnChange += document => _dialogEducation.GetPassport(this);

            ChangeCommand = ReactiveCommand.Create(Change);
            DeleteCommand = ReactiveCommand.Create(Delete);

            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddDocumentCommand = ReactiveCommand.Create(() =>
            {
                education.Add(this);
                closeWindow();
            });
        }
    }
}