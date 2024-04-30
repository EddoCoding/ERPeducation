using ERPeducation.ViewModels.Modules.DeanRoom.Repository;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Service
{
    public interface IDeanRoomService
    {
        void OpenWindowCreateFaculty(IDeanRoomRepository deanRoomRepository);
        void OpenWindowEditFaculty(IDeanRoomRepository deanRoomRepository);
    }
}