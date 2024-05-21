using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.EnrolleeVM;
using ERPeducation.ViewModels.Modules.DeanRoom.FacultyVM;
using ERPeducation.ViewModels.Modules.DeanRoom.FormVM;
using ERPeducation.ViewModels.Modules.DeanRoom.GroupVM;
using ERPeducation.ViewModels.Modules.DeanRoom.LevelVM;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ERPeducation.ViewModels.Modules.DeanRoom.StudentVM;
using ERPeducation.ViewModels.Modules.DeanRoom.TypeGroupVM;
using ERPeducation.Views.DeanRoom.WindowEnrolleeGroup;
using ERPeducation.Views.DeanRoom.WindowFaculty;
using ERPeducation.Views.DeanRoom.WindowForm;
using ERPeducation.Views.DeanRoom.WindowGroup;
using ERPeducation.Views.DeanRoom.WindowLevel;
using ERPeducation.Views.DeanRoom.WindowStudent;
using ERPeducation.Views.DeanRoom.WindowTypeGroup;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Service
{
    public class DeanRoomService : IDeanRoomService
    {
        // -- Открытие окна добавления факультета --
        // -- Открытие окна изменения факультета --
        public void OpenWindowCreateFaculty(IDeanRoomRepository deanRoomRepository)
        {
            AddFacultyWindow facultyWindow = new AddFacultyWindow();
            facultyWindow.DataContext = new AddFacultyViewModel(deanRoomRepository, facultyWindow.Close);
            facultyWindow.ShowDialog();
        }                            
        public void OpenWindowEditFaculty(IDeanRoomRepository deanRoomRepository, Faculty faculty)
        {
            EditFacultyWindow editfacultyWindow = new EditFacultyWindow();
            editfacultyWindow.DataContext = new EditFacultyViewModel(deanRoomRepository, faculty, editfacultyWindow.Close);
            editfacultyWindow.ShowDialog();
        }


        // -- Открытие окна добавления уровня подготовки --
        // -- Открытие окна изменения уровня подготовки --
        public void OpenWindowCreateLevel(IDeanRoomRepository deanRoomRepository, Faculty faculty)
        {
            AddLevelWindow levelWindow = new AddLevelWindow();
            levelWindow.DataContext = new AddLevelViewModel(deanRoomRepository, faculty, levelWindow.Close);
            levelWindow.ShowDialog();
        }             
        public void OpenWindowEditLevel(IDeanRoomRepository deanRoomRepository, LvlOfTraining level, Faculty faculty)
        {
            EditLevelWindow editLevelWindow = new EditLevelWindow();
            editLevelWindow.DataContext = new EditLevelViewModel(deanRoomRepository, level, faculty, editLevelWindow.Close);
            editLevelWindow.ShowDialog();
        }


        // -- Открытие окна добавления формы подготовки
        // -- Открытие окна изменения формы подготовки
        public void OpenWindowCreateForm(IDeanRoomRepository deanRoomRepository, LvlOfTraining level, Faculty faculty)
        {
            AddFormWindow formWindow = new AddFormWindow();
            formWindow.DataContext = new AddFormViewModel(deanRoomRepository, level, faculty, formWindow.Close);
            formWindow.ShowDialog();
        }  
        public void OpenWindowEditForm(IDeanRoomRepository deanRoomRepository, FormsOfTraining form, LvlOfTraining level, Faculty faculty)
        {
            EditFormWindow editFormWindow = new EditFormWindow();
            editFormWindow.DataContext = new EditFormViewModel(deanRoomRepository, form, level, faculty, editFormWindow.Close);
            editFormWindow.ShowDialog();
        }


        // -- Открытие окна добавления типа группы
        // -- Открытие окна изменения типа группы
        public void OpenWindowCreateTypeGroup(IDeanRoomRepository deanRoomRepository, FormsOfTraining form, LvlOfTraining level, Faculty faculty)
        {
            AddTypeGroupWindow typeGroupWindow = new AddTypeGroupWindow();
            typeGroupWindow.DataContext = new AddTypeGroupViewModel(deanRoomRepository, form, level, faculty, typeGroupWindow.Close);
            typeGroupWindow.ShowDialog();
        }
        public void OpenWindowEditTypeGroup(IDeanRoomRepository deanRoomRepository, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty)
        {
            EditTypeGroupWindow editTypeGroupWindow = new EditTypeGroupWindow();
            editTypeGroupWindow.DataContext = new EditTypeGroupViewModel(deanRoomRepository, typeGroup, form, level, faculty, editTypeGroupWindow.Close);
            editTypeGroupWindow.ShowDialog();
        }


        // -- Открытие окна добавления группы
        // -- Открытие окна изменения группы
        public void OpenWindowCreateGroup(IDeanRoomRepository deanRoomRepository, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty)
        {
            AddGroupWindow groupWindow = new AddGroupWindow();
            groupWindow.DataContext = new AddGroupViewModel(deanRoomRepository, typeGroup, form, level, faculty, groupWindow.Close);
            groupWindow.ShowDialog();
        }
        public void OpenWindowEditGroup(IDeanRoomRepository deanRoomRepository, Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty) 
        {
            EditGroupWindow editGroupWindow = new EditGroupWindow();
            editGroupWindow.DataContext = new EditGroupViewModel(deanRoomRepository, group, typeGroup, form, level, faculty, editGroupWindow.Close);
            editGroupWindow.ShowDialog();
        }


        // -- Открытие окна добавления студента
        // -- Открытие окна изменения студента
        public void OpenWindowCreateStudent(IDeanRoomRepository deanRoomRepository, Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty) 
        {
            AddStudentWindow studentWindow = new AddStudentWindow();
            studentWindow.DataContext = new AddStudentViewModel(deanRoomRepository, group, typeGroup, form, level, faculty, studentWindow.Close);
            studentWindow.ShowDialog();
        }
        public void OpenWindowEditStudent(IDeanRoomRepository deanRoomRepository, Student student, Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty) 
        {
            EditStudentWindow editStudentWindow = new EditStudentWindow();
            editStudentWindow.DataContext = new EditStudentViewModel(deanRoomRepository, student, group, typeGroup, form, level, faculty, editStudentWindow.Close);
            editStudentWindow.ShowDialog();
        }


        // -- Открытие окна добавления абитуриента
        public void OpenWindowAddEnrollee(Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty, IDeanRoomRepository deanRoomRepository)
        {
            AddEnrolleeGroupWindow window = new AddEnrolleeGroupWindow();
            window.DataContext = new AddEnrolleeGroupViewModel(group, typeGroup, form, level, faculty, deanRoomRepository, window.Close);
            window.ShowDialog();
        }


        // -- Открытие окна профиля студента
        public void OpenWindowStudentProfile(Student student)
        {
            ShowStudentProfileWindow window = new ShowStudentProfileWindow();
            window.DataContext = new ShowStudentProfileViewModel(student, window.Close);
            window.ShowDialog();
        }
    }
}