using ERPeducation.Models;
using ERPeducation.ViewModels;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Old;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Old.PersonalDocuments;
using ERPeducation.Views.AdmissionCampaign;
using ERPeducation.Views.AdmissionCampaign.NewView;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Windows.Controls;

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
        public void GetPassport(PersonalDocumentBase document)
        {
            PassportView view = new PassportView();
            document.CloseWindowCommand = ReactiveCommand.Create(view.Close);
            document.AddDocumentCommand = ReactiveCommand.Create(view.Close);
            view.DataContext = document;
            view.ShowDialog();
        }

        public void GetSnils(ObservableCollection<PersonalDocumentBase> documents)
        {
            SnilsView view = new SnilsView();
            view.DataContext = new SnilsViewModel(documents, view.Close);
            view.ShowDialog();
        }
        public void GetSnils(PersonalDocumentBase document)
        {
            SnilsView view = new SnilsView();
            document.CloseWindowCommand = ReactiveCommand.Create(view.Close);
            document.AddDocumentCommand = ReactiveCommand.Create(view.Close);
            view.DataContext = document;
            view.ShowDialog();
        }

        public void GetInn(ObservableCollection<PersonalDocumentBase> documents)
        {
            InnView view = new InnView();
            view.DataContext = new InnViewModel(documents, view.Close);
            view.ShowDialog();
        }
        public void GetInn(PersonalDocumentBase document)
        {
            InnView view = new InnView();
            document.CloseWindowCommand = ReactiveCommand.Create(view.Close);
            document.AddDocumentCommand = ReactiveCommand.Create(view.Close);
            view.DataContext = document;
            view.ShowDialog();
        }

        public void GetForeignPassport(ObservableCollection<PersonalDocumentBase> documents)
        {
            ForeignPassportView view = new ForeignPassportView();
            view.DataContext = new ForeignPassportViewModel(documents, view.Close);
            view.ShowDialog();
        }
        public void GetForeignPassport(PersonalDocumentBase document)
        {
            ForeignPassportView view = new ForeignPassportView();
            document.CloseWindowCommand = ReactiveCommand.Create(view.Close);
            document.AddDocumentCommand = ReactiveCommand.Create(view.Close);
            view.DataContext = document;
            view.ShowDialog();
        }

        public void GetUserControlDocument(UserControl userControl, PersonalDocumentBase document)
        {
            if(document.TypeDocument == "Паспорт")
            {
                userControl.Content = new PassportUserControl() { DataContext = document };
                return;
            }
            if (document.TypeDocument == "Снилс")
            {
                userControl.Content = new SnilsUserControl() { DataContext = document };
                return;
            }
            if (document.TypeDocument == "ИНН")
            {
                userControl.Content = new InnUserControl() { DataContext = document };
                return;
            }
            if (document.TypeDocument == "Паспорт иностранного гражданина")
            {
                userControl.Content = new ForeignPassportUserControl() { DataContext = document };
                return;
            }
        }

        public void ChangeEnrollee(AddChangeEnrolleeViewModel enrollee, MainTabControl<MainTabItem> data) =>
            data.TabItem.Add(new MainTabItem("Абитуриент", new AddEnrolleView() { DataContext = enrollee }));
    }
}