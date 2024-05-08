using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Service
{
    public interface IDeanRoomService
    {
        void OpenWindowCreateFaculty(IDeanRoomRepository deanRoomRepository);
        void OpenWindowEditFaculty(IDeanRoomRepository deanRoomRepository, Faculty faculty);

        void OpenWindowCreateLevel(IDeanRoomRepository deanRoomRepository, Faculty faculty);
        void OpenWindowEditLevel(IDeanRoomRepository deanRoomRepository, LvlOfTraining level, Faculty faculty);

        void OpenWindowCreateForm(IDeanRoomRepository deanRoomRepository, LvlOfTraining level, Faculty faculty);
        void OpenWindowEditForm(IDeanRoomRepository deanRoomRepository, FormsOfTraining form, LvlOfTraining level, Faculty faculty);

        void OpenWindowCreateTypeGroup(IDeanRoomRepository deanRoomRepository, FormsOfTraining form, LvlOfTraining level, Faculty faculty);
        void OpenWindowEditTypeGroup(IDeanRoomRepository deanRoomRepository, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty);

        void OpenWindowCreateGroup(IDeanRoomRepository deanRoomRepository, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty);
        void OpenWindowEditGroup(IDeanRoomRepository deanRoomRepository, Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty);

        void OpenWindowCreateStudent(IDeanRoomRepository deanRoomRepository, Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty);
        void OpenWindowEditStudent(IDeanRoomRepository deanRoomRepository, Student student, Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty);

        void OpenWindowAddEnrollee(Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty, IDeanRoomRepository deanRoomRepository);
    }
}