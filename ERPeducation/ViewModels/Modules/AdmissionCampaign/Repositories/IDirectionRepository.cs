using ERPeducation.Models.AdmissionCampaign.Directions.TestEGG;
using ERPeducation.Models.DeanRoom;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Repositories
{
    public interface IDirectionRepository
    {
        ObservableCollection<Faculty> Faculties { get; set; }
        void GetFaculties();


        ObservableCollection<LvlOfTraining> Levels { get; set; }
        void GetLevels(Faculty faculty);


        ObservableCollection<FormsOfTraining> Forms { get; set; }
        void GetForms(LvlOfTraining level);


        ObservableCollection<TypeGroup> Types { get; set; }
        void GetTypes(FormsOfTraining form);


        ObservableCollection<Group> Groups { get; set; }
        void GetGroups(TypeGroup typeGroup);


        ObservableCollection<TestEGEBase> Tests { get; set; }
        void CreateTest(TestEGEBase test);
        void DelTest(TestEGEBase test);
        void CreateEGG(TestEGEBase egg);
        void DelEGG(TestEGEBase egg);
    }
}