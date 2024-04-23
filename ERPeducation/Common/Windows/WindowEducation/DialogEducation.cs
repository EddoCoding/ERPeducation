using ERPeducation.ViewModels.Modules.AdmissionCampaign.Old.EducationDocuments;
using ERPeducation.Views.AdmissionCampaign.UserControlEducations;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERPeducation.Common.Windows.WindowEducation
{
    public class DialogEducation : IDialogEducation
    {
        public void GetBasicGeneral(ObservableCollection<EducationDocumentBase> education)
        {
            BasicGeneralView view = new BasicGeneralView();
            view.DataContext = new BasicGeneralEducationViewModel(education, view.Close);
            view.ShowDialog();
        }
        public void GetBasicGeneral(EducationDocumentBase education)
        {
            BasicGeneralView view = new BasicGeneralView();
            education.CloseWindowCommand = ReactiveCommand.Create(view.Close);
            education.AddDocumentCommand = ReactiveCommand.Create(view.Close);
            view.DataContext = education;
            view.ShowDialog();
        }


        public void GetBasicAverage(ObservableCollection<EducationDocumentBase> education)
        {
            BasicAverageView view = new BasicAverageView();
            view.DataContext = new BasicAverageEducationViewModel(education, view.Close);
            view.ShowDialog();
        }
        public void GetBasicAverage(EducationDocumentBase education)
        {
            BasicAverageView view = new BasicAverageView();
            education.CloseWindowCommand = ReactiveCommand.Create(view.Close);
            education.AddDocumentCommand = ReactiveCommand.Create(view.Close);
            view.DataContext = education;
            view.ShowDialog();
        }


        public void GetSpo(ObservableCollection<EducationDocumentBase> education)
        {
            SpoView view = new SpoView();
            view.DataContext = new EducationSpoViewModel(education, view.Close);
            view.ShowDialog();
        }
        public void GetSpo(EducationDocumentBase education)
        {
            SpoView view = new SpoView();
            education.CloseWindowCommand = ReactiveCommand.Create(view.Close);
            education.AddDocumentCommand = ReactiveCommand.Create(view.Close);
            view.DataContext = education;
            view.ShowDialog();
        }


        public void GetUndergraduate(ObservableCollection<EducationDocumentBase> education)
        {
            UndergraduateView view = new UndergraduateView();
            view.DataContext = new EducationUndergraduateViewModel(education, view.Close);
            view.ShowDialog();
        }
        public void GetUndergraduate(EducationDocumentBase education)
        {
            UndergraduateView view = new UndergraduateView();
            education.CloseWindowCommand = ReactiveCommand.Create(view.Close);
            education.AddDocumentCommand = ReactiveCommand.Create(view.Close);
            view.DataContext = education;
            view.ShowDialog();
        }


        public void GetMaster(ObservableCollection<EducationDocumentBase> education)
        {
            MasterView view = new MasterView();
            view.DataContext = new EducationMasterViewModel(education, view.Close);
            view.ShowDialog();
        }
        public void GetMaster(EducationDocumentBase education)
        {
            MasterView view = new MasterView();
            education.CloseWindowCommand = ReactiveCommand.Create(view.Close);
            education.AddDocumentCommand = ReactiveCommand.Create(view.Close);
            view.DataContext = education;
            view.ShowDialog();
        }


        public void GetSpecialty(ObservableCollection<EducationDocumentBase> education)
        {
            SpecialtyView view = new SpecialtyView();
            view.DataContext = new EducationSpecialtyViewModel(education, view.Close);
            view.ShowDialog();
        }
        public void GetSpecialty(EducationDocumentBase education)
        {
            SpecialtyView view = new SpecialtyView();
            education.CloseWindowCommand = ReactiveCommand.Create(view.Close);
            education.AddDocumentCommand = ReactiveCommand.Create(view.Close);
            view.DataContext = education;
            view.ShowDialog();
        }


        public void GetUserControlEducation(UserControl userControl, EducationDocumentBase education)
        {
            switch (education.TypeEducation)
            {
                case "Основное общее образование":
                    userControl.Content = new BasicGeneralUserControl() { DataContext = education };
                    break;
                case "Среднее общее образование":
                    userControl.Content = new BasicAverageUserControl() { DataContext = education };
                    break;
                case "Среднее профессиональное образование":
                    userControl.Content = new SpoUserControl() { DataContext = education };
                    break;
                case "Бакалавриат":
                    userControl.Content = new UndergraduateUserControl() { DataContext = education };
                    break;
                case "Магистратура":
                    userControl.Content = new MasterUserControl() { DataContext = education };
                    break;
                case "Специалитет":
                    userControl.Content = new SpecialtyUserControl() { DataContext = education };
                    break;
            }
        }
    }
}