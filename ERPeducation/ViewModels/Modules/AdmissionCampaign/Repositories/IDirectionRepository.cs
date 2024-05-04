using ERPeducation.Models.DeanRoom;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Repositories
{
    public interface IDirectionRepository
    {
        ObservableCollection<Faculty> Faculties { get; set; }
        ObservableCollection<LvlOfTraining> Levels { get; set; }
        ObservableCollection<FormsOfTraining> Forms { get; set; }
        ObservableCollection<TypeGroup> Types { get; set; }
        ObservableCollection<Group> Groups { get; set; }
        void GetFaculties();

        void GetLevels(Faculty faculty);
        void GetForms(LvlOfTraining level);
        void GetTypes(FormsOfTraining form);
        void GetGroups(TypeGroup typeGroup);
    }
}