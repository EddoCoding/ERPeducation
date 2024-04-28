using ReactiveUI;
using System.Reactive;
using System;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents.EditDocument
{
    public class EditINNViewModel
    {
        public INN INN { get; set; }

        public ReactiveCommand<Unit, Unit> SaveDocumentСommand { get; set; }

        Action closeWindow;

        public EditINNViewModel(DocumentBase document, Action closeWindow)
        {
            INN = (INN)document;
            this.closeWindow = closeWindow;

            SaveDocumentСommand = ReactiveCommand.Create(Save);
        }

        void Save() => closeWindow();
    }
}
