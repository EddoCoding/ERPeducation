using ERPeducation.ViewModels.Modules.DeanRoom.FacultyVM;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ERPeducation.Views.DeanRoom.WindowFaculty;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Service
{
    public class DeanRoomService : IDeanRoomService
    {
        public void OpenWindowCreateFaculty(IDeanRoomRepository deanRoomRepository)
        {
            AddFacultyWindow facultyWindow = new AddFacultyWindow();
            facultyWindow.DataContext = new AddFacultyViewModel(deanRoomRepository, facultyWindow.Close);
            facultyWindow.ShowDialog();
        }
        public void OpenWindowEditFaculty(IDeanRoomRepository deanRoomRepository) { }
    }
}