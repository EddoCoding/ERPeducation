using ERPeducation.Common.Windows.WindowEducation;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.EducationDocuments
{
    public abstract class EducationDocumentBase
    {
        public string TextAddChange { get; set; } = "Добавить";

        public string TypeEducation { get; set; } = string.Empty;
        public string IssuedBy { get; set; } = string.Empty;
        public DateTime DateOfIssue { get; set; }
        public bool WithHonours { get; set; }


        public ReactiveCommand<Unit, Unit> ChangeCommand { get; set; }
        public ReactiveCommand<Unit, Unit> DeleteCommand { get; set; }
        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Unit, Unit> AddDocumentCommand { get; set; }

        public event Action<EducationDocumentBase>? OnChange;
        public event Action<EducationDocumentBase>? OnDelete;

        public void Change() => OnChange?.Invoke(this);
        public void Delete() => OnDelete?.Invoke(this);


        protected IDialogEducation _dialogEducation;
        public EducationDocumentBase()
        {
            if (_dialogEducation == null)
                _dialogEducation = new DialogEducation();
        }
    }
}
