using ReactiveUI;
using System.Collections.ObjectModel;
using System;
using ReactiveUI.Fody.Helpers;
using ERPeducation.Common.Interface;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.EducationDocuments
{
    public class BasicAverageEducationViewModel : EducationDocumentBase
    {
        [Reactive] public string CodeSeriesNumber { get; set; } = string.Empty;



        //КОНСТРУКТОР ДЛЯ ИЗМЕНЕНИЯ ОБЪЕКТА
        public BasicAverageEducationViewModel(BasicAverageEducationViewModel education, Action closeWindow)
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
        public BasicAverageEducationViewModel(ObservableCollection<EducationDocumentBase> education, ObservableCollection<ISubmitted> submittedDocuments, Action closeWindow)
        {
            TypeEducation = "Среднее общее образование";
            TypeDocument = "Аттестат о среднем общем образовании";

            OnChange += document => _dialogEducation.GetBasicAverage(this);

            ChangeCommand = ReactiveCommand.Create(Change);
            DeleteCommand = ReactiveCommand.Create(Delete);

            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddDocumentCommand = ReactiveCommand.Create(() =>
            {
                education.Add(this);
                submittedDocuments.Add(this);
                closeWindow();
            });
        }
    }
}
