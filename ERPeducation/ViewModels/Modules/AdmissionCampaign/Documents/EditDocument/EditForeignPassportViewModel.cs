using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents.EditDocument
{
    public class EditForeignPassportViewModel
    {
        public ForeignPassport ForeignPassport { get; set; }

        public ReactiveCommand<Unit, Unit> SaveDocumentСommand { get; set; }

        Action closeWindow;

        public EditForeignPassportViewModel(DocumentBase document, Action closeWindow)
        {
            ForeignPassport = (ForeignPassport)document;
            this.closeWindow = closeWindow;

            SaveDocumentСommand = ReactiveCommand.Create(Save);
        }

        void Save() => closeWindow();
    }
}
