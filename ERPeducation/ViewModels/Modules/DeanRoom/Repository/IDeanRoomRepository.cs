using ERPeducation.Models;
using ERPeducation.Models.DeanRoom;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Repository
{
    public interface IDeanRoomRepository
    {
        ObservableCollection<Faculty> Faculties {get; set;}
        void CreateFaculty(Faculty faculty);
        void EditFaculty(Faculty oldNameFaculty, Faculty NewNameFaculty);
        void DeleteFaculty(Faculty faculty);


        ObservableCollection<LvlOfTraining> Levels {get; set;}
        void CreateLevel(LvlOfTraining level, Faculty faculty);
        void EditLevel(LvlOfTraining oldNamelevel, LvlOfTraining newNamelevel, Faculty faculty);
        void DeleteLevel(LvlOfTraining level, Faculty faculty);


        ObservableCollection<FormsOfTraining> Forms {get; set;}
        void CreateForm(FormsOfTraining form, LvlOfTraining level, Faculty faculty);
        void EditForm(FormsOfTraining oldNameForm, FormsOfTraining newNameForm, LvlOfTraining level, Faculty faculty);
        void DeleteForm(FormsOfTraining form, LvlOfTraining level, Faculty faculty);


        ObservableCollection<TypeGroup> Types {get; set;}
        void CreateTypeGroup(TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty);
        void EditTypeGroup(TypeGroup oldNameTypeGroup, TypeGroup newNameTypeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty);
        void DeleteTypeGroup(TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty);


        ObservableCollection<Group> Groups {get; set;}
        void CreateGroup(Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty);
        void EditGroup(Group oldNameGroup, Group newNameGroup, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty);
        void DeleteGroup(Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty);


        ObservableCollection<Student> Students {get; set;}
        void CreateStudent(Student student, Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty);
        void EditStudent(Student oldStudent, Student newStudent, Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty);
        void DeleteStudent(Student student, Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty);


        ICollection<Faculty> GetJsonFaculty();
        IEnumerable<Syllabus> GetSyllabus();

        void SelectedFaculty(Faculty faculty);
        void SelectedLevel(LvlOfTraining level);
        void SelectedForm(FormsOfTraining form);
        void SelectedTypeGroup(TypeGroup typeGroup);
        void SelectedGroup(Group group);
    }
}
