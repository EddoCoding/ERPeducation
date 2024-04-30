using ERPeducation.Models.DeanRoom;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Repository
{
    public interface IDeanRoomRepository
    {
        ObservableCollection<Faculty> Faculties {get; set;}
        ObservableCollection<string> Levels {get; set;}
        ObservableCollection<string> Forms {get; set;}
        ObservableCollection<string> Types {get; set;}
        ObservableCollection<string> Groups {get; set;}
        ObservableCollection<string> Students {get; set;}

        void CreateFaculty(Faculty faculty);
        void DeleteFaculty(Faculty faculty);
    }
}
