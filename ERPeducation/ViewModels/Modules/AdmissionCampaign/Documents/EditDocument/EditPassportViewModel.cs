using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents.EditDocument
{
    public class EditPassportViewModel
    {
        public Passport Passport { get; set; }

        public ReactiveCommand<Unit, Unit> SaveDocumentCommand { get; set; }

        Action closeWindow;

        public EditPassportViewModel(DocumentBase document, Action closeWindow)
        {
            Passport = (Passport)document;
            this.closeWindow = closeWindow;

            SaveDocumentCommand = ReactiveCommand.Create(Save);
        }

        void Save() => closeWindow();
    }
}
