using ERPeducation.Common.Windows.WindowEducation;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.EducationDocuments
{
    public abstract class EducationDocumentBase : ReactiveObject
    {
        [Reactive] public string TextAddChange { get; set; } = "Добавить";
        
        [Reactive] public string TypeEducation { get; set; } = string.Empty;
        [Reactive] public string TypeDocument{ get; set; } = string.Empty;
        [Reactive] public string IssuedBy { get; set; } = string.Empty;
        [Reactive] public DateTime DateOfIssue { get; set; }
        [Reactive] public bool WithHonours { get; set; }


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
