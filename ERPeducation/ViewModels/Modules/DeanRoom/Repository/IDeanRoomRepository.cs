using ERPeducation.Models.DeanRoom;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Repository
{
    public interface IDeanRoomRepository
    {
        ObservableCollection<Faculty> Faculties {get; set;}
        ObservableCollection<LvlOfTraining> Levels {get; set;}
        ObservableCollection<FormsOfTraining> Forms {get; set;}
        ObservableCollection<TypeGroup> Types {get; set;}
        ObservableCollection<Group> Groups {get; set;}
        ObservableCollection<Student> Students {get; set;}

        ICollection<Faculty> GetJsonFaculty();

        void CreateFaculty(Faculty faculty);
        void DeleteFaculty(Faculty faculty);

        void DeleteLevel(LvlOfTraining level);
        void DeleteForm(FormsOfTraining form);
        void DeleteTypeGroup(TypeGroup typeGroup);
        void DeleteGroup(Group group);
        void DeleteStudent(Student student);
    }
}
