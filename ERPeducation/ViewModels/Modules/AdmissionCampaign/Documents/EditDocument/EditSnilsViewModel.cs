using ReactiveUI;
using System.Reactive;
using System;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents.EditDocument
{
    public class EditSnilsViewModel
    {
        public Snils Snils { get; set; }

        public ReactiveCommand<Unit, Unit> SaveDocumentСommand { get; set; }

        Action closeWindow;

        public EditSnilsViewModel(DocumentBase document, Action closeWindow)
        {
            Snils = (Snils)document;
            this.closeWindow = closeWindow;

            SaveDocumentСommand = ReactiveCommand.Create(Save);
        }

        void Save() => closeWindow();
    }
}
