using ERPeducation.Common.Interface;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.EducationDocuments;
using ERPeducation.Views.AdmissionCampaign.UserControlEducations;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ERPeducation.Common.Windows.WindowEducation
{
    public class DialogEducation : IDialogEducation
    {
        public void GetBasicGeneral(ObservableCollection<EducationDocumentBase> education, ObservableCollection<ISubmitted> submittedDocuments)
        {
            BasicGeneralView view = new BasicGeneralView();
            view.DataContext = new BasicGeneralEducationViewModel(education, submittedDocuments, view.Close);
            view.ShowDialog();
        }
        public void GetBasicGeneral(BasicGeneralEducationViewModel education)
        {
            BasicGeneralView view = new BasicGeneralView();
            view.DataContext = new BasicGeneralEducationViewModel(education, view.Close);
            view.ShowDialog();
        }


        public void GetBasicAverage(ObservableCollection<EducationDocumentBase> education, ObservableCollection<ISubmitted> submittedDocuments)
        {
            BasicAverageView view = new BasicAverageView();
            view.DataContext = new BasicAverageEducationViewModel(education, submittedDocuments, view.Close);
            view.ShowDialog();
        }
        public void GetBasicAverage(BasicAverageEducationViewModel education)
        {
            BasicAverageView view = new BasicAverageView();
            view.DataContext = new BasicAverageEducationViewModel(education, view.Close);
            view.ShowDialog();
        }


        public void GetSpo(ObservableCollection<EducationDocumentBase> education, ObservableCollection<ISubmitted> submittedDocuments)
        {
            SpoView view = new SpoView();
            view.DataContext = new EducationSpoViewModel(education, submittedDocuments, view.Close);
            view.ShowDialog();
        }
        public void GetSpo(EducationSpoViewModel education)
        {
            SpoView view = new SpoView();
            view.DataContext = new EducationSpoViewModel(education, view.Close);
            view.ShowDialog();
        }


        public void GetUndergraduate(ObservableCollection<EducationDocumentBase> education, ObservableCollection<ISubmitted> submittedDocuments)
        {
            UndergraduateView view = new UndergraduateView();
            view.DataContext = new EducationUndergraduateViewModel(education, submittedDocuments, view.Close);
            view.ShowDialog();
        }
        public void GetUndergraduate(EducationUndergraduateViewModel education)
        {
            UndergraduateView view = new UndergraduateView();
            view.DataContext = new EducationUndergraduateViewModel(education, view.Close);
            view.ShowDialog();
        }


        public void GetMaster(ObservableCollection<EducationDocumentBase> education, ObservableCollection<ISubmitted> submittedDocuments)
        {
            MasterView view = new MasterView();
            view.DataContext = new EducationMasterViewModel(education, submittedDocuments, view.Close);
            view.ShowDialog();
        }
        public void GetMaster(EducationMasterViewModel education)
        {
            MasterView view = new MasterView();
            view.DataContext = new EducationMasterViewModel(education, view.Close);
            view.ShowDialog();
        }


        public void GetSpecialty(ObservableCollection<EducationDocumentBase> education, ObservableCollection<ISubmitted> submittedDocuments)
        {
            SpecialtyView view = new SpecialtyView();
            view.DataContext = new EducationSpecialtyViewModel(education, submittedDocuments, view.Close);
            view.ShowDialog();
        }
        public void GetSpecialty(EducationSpecialtyViewModel education)
        {
            SpecialtyView view = new SpecialtyView();
            view.DataContext = new EducationSpecialtyViewModel(education, view.Close);
            view.ShowDialog();
        }


        public void GetUserControlEducation(UserControl userControl, EducationDocumentBase education)
        {
            if (education is BasicGeneralEducationViewModel)
            {
                userControl.Content = new BasicGeneralUserControl() { DataContext = education };
                return;
            }
            if (education is BasicAverageEducationViewModel)
            {
                userControl.Content = new BasicAverageUserControl() { DataContext = education };
                return;
            }
            if (education is EducationSpoViewModel)
            {
                userControl.Content = new SpoUserControl() { DataContext = education };
                return;
            }
            if (education is EducationUndergraduateViewModel)
            {
                userControl.Content = new UndergraduateUserControl() { DataContext = education };
                return;
            }
            if (education is EducationMasterViewModel)
            {
                userControl.Content = new MasterUserControl() { DataContext = education };
                return;
            }
            if (education is EducationSpecialtyViewModel)
            {
                userControl.Content = new SpecialtyUserControl() { DataContext = education };
                return;
            }
        }
    }
}