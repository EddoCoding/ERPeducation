using ReactiveUI.Fody.Helpers;
using ReactiveUI;
using System.Collections.ObjectModel;
using System;
using ERPeducation.Common.Interface;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.EducationDocuments
{
    public class EducationSpecialtyViewModel : EducationDocumentBase
    {
        [Reactive] public string RegistrationNumber { get; set; } = string.Empty;
        [Reactive] public string SelectedFormOfStudy { get; set; } = string.Empty;
        [Reactive] public string Series { get; set; } = string.Empty;
        [Reactive] public string Number { get; set; } = string.Empty;
        [Reactive] public string SeriesSupplement { get; set; } = string.Empty;
        [Reactive] public string NumberSupplement { get; set; } = string.Empty;


        //КОНСТРУКТОР ДЛЯ ИЗМЕНЕНИЯ ОБЪЕКТА
        public EducationSpecialtyViewModel(EducationSpecialtyViewModel education, Action closeWindow)
        {
            TextAddChange = "Изменить";

            TypeEducation = education.TypeEducation;
            TypeDocument = education.TypeDocument;
            IssuedBy = education.IssuedBy;
            DateOfIssue = education.DateOfIssue;
            WithHonours = education.WithHonours;
            RegistrationNumber = education.RegistrationNumber;
            SelectedFormOfStudy = education.SelectedFormOfStudy;
            Series = education.Series;
            Number = education.Number;
            SeriesSupplement = education.SeriesSupplement;
            NumberSupplement = education.NumberSupplement;

            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddDocumentCommand = ReactiveCommand.Create(() =>
            {
                education.IssuedBy = IssuedBy;
                education.DateOfIssue = DateOfIssue;
                education.WithHonours = WithHonours;
                education.RegistrationNumber = RegistrationNumber;
                education.SelectedFormOfStudy = SelectedFormOfStudy;
                education.Series = Series;
                education.Number = Number;
                education.SeriesSupplement = SeriesSupplement;
                education.NumberSupplement = NumberSupplement;

                closeWindow();
            });
        }

        //ОСНОВНОЙ КОНСТРУКТОР ДЛЯ НОВОГО ДОКУМЕНТА
        public EducationSpecialtyViewModel(ObservableCollection<EducationDocumentBase> education, ObservableCollection<ISubmitted> submittedDocuments, Action closeWindow)
        {
            TypeEducation = "Специалитет";
            TypeDocument = "Диплом специалиста";

            OnChange += document => _dialogEducation.GetSpecialty(this);

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
