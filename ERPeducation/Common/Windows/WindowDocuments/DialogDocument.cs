using ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Windows.WindowDocuments
{
    public class DialogDocument : IDialogDocument
    {
        public void GetPassport(ObservableCollection<PersonalDocumentBase> documents)
        {
            PassportView view = new PassportView();
            view.DataContext = new PassportViewModel(documents, view.Close);
            view.ShowDialog();
        }
        public void GetPassport(PassportViewModel document)
        {
            PassportView view = new PassportView();
            view.DataContext = new PassportViewModel(document, view.Close);
            view.ShowDialog();
        }

        public void GetSnils(ObservableCollection<PersonalDocumentBase> documents)
        {
            SnilsView view = new SnilsView();
            view.DataContext = new SnilsViewModel(documents, view.Close);
            view.ShowDialog();
        }
        public void GetSnils(SnilsViewModel document)
        {
            SnilsView view = new SnilsView();
            view.DataContext = new SnilsViewModel(document, view.Close);
            view.ShowDialog();
        }

        public void GetInn(ObservableCollection<PersonalDocumentBase> documents)
        {
            InnView view = new InnView();
            view.DataContext = new InnViewModel(documents, view.Close);
            view.ShowDialog();
        }
        public void GetInn(InnViewModel document)
        {
            InnView view = new InnView();
            view.DataContext = new InnViewModel(document, view.Close);
            view.ShowDialog();
        }

        public void GetForeignPassport(ObservableCollection<PersonalDocumentBase> documents)
        {
            ForeignPassportView view = new ForeignPassportView();
            view.DataContext = new ForeignPassportViewModel(documents, view.Close);
            view.ShowDialog();
        }
        public void GetForeignPassport(ForeignPassportViewModel document)
        {
            ForeignPassportView view = new ForeignPassportView();
            view.DataContext = new ForeignPassportViewModel(document, view.Close);
            view.ShowDialog();
        }
    }
}