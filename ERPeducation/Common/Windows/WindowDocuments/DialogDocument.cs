using ERPeducation.Common.Interface;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments;
using ERPeducation.Views.AdmissionCampaign;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERPeducation.Common.Windows.WindowDocuments
{
    public class DialogDocument : IDialogDocument
    {
        public void GetPassport(ObservableCollection<PersonalDocumentBase> documents, ObservableCollection<ISubmitted> submittedDocuments)
        {
            PassportView view = new PassportView();
            view.DataContext = new PassportViewModel(documents, submittedDocuments, view.Close);
            view.ShowDialog();
        }
        public void GetPassport(PassportViewModel document)
        {
            PassportView view = new PassportView();
            view.DataContext = new PassportViewModel(document, view.Close);
            view.ShowDialog();
        }

        public void GetSnils(ObservableCollection<PersonalDocumentBase> documents, ObservableCollection<ISubmitted> submittedDocuments)
        {
            SnilsView view = new SnilsView();
            view.DataContext = new SnilsViewModel(documents, submittedDocuments, view.Close);
            view.ShowDialog();
        }
        public void GetSnils(SnilsViewModel document)
        {
            SnilsView view = new SnilsView();
            view.DataContext = new SnilsViewModel(document, view.Close);
            view.ShowDialog();
        }

        public void GetInn(ObservableCollection<PersonalDocumentBase> documents, ObservableCollection<ISubmitted> submittedDocuments)
        {
            InnView view = new InnView();
            view.DataContext = new InnViewModel(documents, submittedDocuments, view.Close);
            view.ShowDialog();
        }
        public void GetInn(InnViewModel document)
        {
            InnView view = new InnView();
            view.DataContext = new InnViewModel(document, view.Close);
            view.ShowDialog();
        }

        public void GetForeignPassport(ObservableCollection<PersonalDocumentBase> documents, ObservableCollection<ISubmitted> submittedDocuments)
        {
            ForeignPassportView view = new ForeignPassportView();
            view.DataContext = new ForeignPassportViewModel(documents, submittedDocuments, view.Close);
            view.ShowDialog();
        }
        public void GetForeignPassport(ForeignPassportViewModel document)
        {
            ForeignPassportView view = new ForeignPassportView();
            view.DataContext = new ForeignPassportViewModel(document, view.Close);
            view.ShowDialog();
        }

        public void GetUserControlDocument(UserControl userControl, PersonalDocumentBase document)
        {
            if(document is PassportViewModel)
            {
                userControl.Content = new PassportUserControl() { DataContext = document };
                return;
            }
            if (document is SnilsViewModel)
            {
                userControl.Content = new SnilsUserControl() { DataContext = document };
                return;
            }
            if (document is InnViewModel)
            {
                userControl.Content = new InnUserControl() { DataContext = document };
                return;
            }
            if (document is ForeignPassportViewModel)
            {
                userControl.Content = new ForeignPassportUserControl() { DataContext = document };
                return;
            }
        }
    }
}