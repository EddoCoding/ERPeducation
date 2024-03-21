using ERPeducation.ViewModels.Modules.AdmissionCampaign.EducationDocuments;
using System.Collections.ObjectModel;

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

        public void GetBasicAverage(ObservableCollection<EducationDocumentBase> education)
        {
            BasicAverageView view = new BasicAverageView();
            //view.DataContext = new BasicAverageEducationViewModel(education, view.Close);
            view.ShowDialog();
        }

        public void GetSpo(ObservableCollection<EducationDocumentBase> education)
        {
            SpoView view = new SpoView();
            //view.DataContext = new EducationSpoViewModel(education, view.Close);
            view.ShowDialog();
        }

        public void GetUndergraduate(ObservableCollection<EducationDocumentBase> education)
        {
            UndergraduateView view = new UndergraduateView();
            //view.DataContext = new EducationUndergraduateViewModel(education, view.Close);
            view.ShowDialog();
        }

        public void GetMaster(ObservableCollection<EducationDocumentBase> education)
        {
            MasterView view = new MasterView();
            //view.DataContext = new EducationMasterViewModel(education, view.Close);
            view.ShowDialog();
        }

        public void GetSpecialty(ObservableCollection<EducationDocumentBase> education)
        {
            SpecialtyView view = new SpecialtyView();
            //view.DataContext = new EducationSpecialtyViewModel(education, view.Close);
            view.ShowDialog();
        }
    }
}