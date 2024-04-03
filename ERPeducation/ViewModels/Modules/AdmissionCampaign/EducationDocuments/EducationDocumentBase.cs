using ERPeducation.Common.Windows.WindowEducation;
using ERPeducation.Models;
using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.EducationDocuments
{
    [JsonObject]
    public class EducationDocumentBase : Check
    {
        [Reactive] public string TextAddChange { get; set; } = "Добавить";
        
        [Reactive] public string TypeEducation { get; set; } = string.Empty;
        [Reactive] public string TypeDocument{ get; set; } = string.Empty;
        [Reactive] public string IssuedBy { get; set; } = string.Empty;
        [Reactive] public DateTime DateOfIssue { get; set; }
        [Reactive] public bool WithHonours { get; set; }


        [JsonIgnore] public ReactiveCommand<Unit, Unit> ChangeCommand { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit, Unit> DeleteCommand { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        [JsonIgnore]  public ReactiveCommand<Unit, Unit> AddDocumentCommand { get; set; }

        public event Action<EducationDocumentBase>? OnChange;
        public event Action<EducationDocumentBase>? OnDelete;

        public void Change() => OnChange?.Invoke(this);
        public void Delete() => OnDelete?.Invoke(this);


        protected IDialogEducation _dialogEducation;
        public EducationDocumentBase()
        {
            if (_dialogEducation == null)
                _dialogEducation = new DialogEducation();

            OnChange += changeEducation;

            ChangeCommand = ReactiveCommand.Create(() =>
            {
                OnChange?.Invoke(this);
            });
            DeleteCommand = ReactiveCommand.Create(() =>
            {
                OnDelete?.Invoke(this);
            });
        }

        void changeEducation(EducationDocumentBase education)
        {
            if (education.TypeEducation == "Основное общее образование") _dialogEducation.GetBasicGeneral(education);
            if (education.TypeEducation == "Среднее общее образование") _dialogEducation.GetBasicAverage(education);
            if (education.TypeEducation == "Среднее профессиональное образование") _dialogEducation.GetSpo(education);
            if (education.TypeEducation == "Бакалавриат") _dialogEducation.GetUndergraduate(education);
            if (education.TypeEducation == "Магистратура") _dialogEducation.GetMaster(education);
            if (education.TypeEducation == "Специалитет") _dialogEducation.GetSpecialty(education);
        }
    }
}