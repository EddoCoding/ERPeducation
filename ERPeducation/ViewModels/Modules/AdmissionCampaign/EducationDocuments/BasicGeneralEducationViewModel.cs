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
        public BasicGeneralEducationViewModel(BasicGeneralEducationViewModel education, Action closeWindow)
        {
            TextAddChange = "Изменить";
            TypeEducation = education.TypeEducation;
            TypeDocument = education.TypeDocument;
            IssuedBy = education.IssuedBy;
            DateOfIssue = education.DateOfIssue;
            WithHonours = education.WithHonours;
            CodeSeriesNumber = education.CodeSeriesNumber;

            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddDocumentCommand = ReactiveCommand.Create(() =>
            {
                education.IssuedBy = IssuedBy;
                education.DateOfIssue = DateOfIssue;
                education.WithHonours = WithHonours;
                education.CodeSeriesNumber = CodeSeriesNumber;

                closeWindow();
            });
        }

        //ОСНОВНОЙ КОНСТРУКТОР ДЛЯ НОВОГО ДОКУМЕНТА
        public BasicGeneralEducationViewModel(ObservableCollection<EducationDocumentBase> education, Action closeWindow) 
        {
            TypeEducation = "Основное общее образование";
            TypeDocument = "Аттестат об основном общем образовании";

            OnChange += document => _dialogEducation.GetBasicGeneral(this);

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