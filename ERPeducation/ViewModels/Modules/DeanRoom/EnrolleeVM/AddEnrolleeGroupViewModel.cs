using ERPeducation.Common.BD;
using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Reactive;
using System.Windows.Forms;

namespace ERPeducation.ViewModels.Modules.DeanRoom.EnrolleeVM
{
    public class AddEnrolleeGroupViewModel
    {
        public ObservableCollection<Enrollee> Enrolless { get; set; }
        public Group Group { get; set; }
        TypeGroup _typeGroup;
        FormsOfTraining _form;
        LvlOfTraining _level;
        Faculty _faculty;

        public ReactiveCommand<Enrollee, Unit> AddEnrolleeCommand { get; set; }

        Action _closeWindow;

        IEnrolleeGroupService _enrolleeService = new EnrolleeGroupService();
        IDeanRoomRepository _deanRoomRepository;
        public AddEnrolleeGroupViewModel(Group group, TypeGroup typeGroup, FormsOfTraining form, LvlOfTraining level, Faculty faculty, IDeanRoomRepository deanRoomRepository, Action closeWindow)
        {
            _deanRoomRepository = deanRoomRepository;
            Group = group;
            _typeGroup = typeGroup;
            _form = form;
            _level = level;
            _faculty = faculty;
            _closeWindow = closeWindow;

            Enrolless = new();
            _enrolleeService.Enrollees.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) Enrolless.Add(e.NewItems[0] as Enrollee);
            };
            _enrolleeService.GetEnrollees(group);

            AddEnrolleeCommand = ReactiveCommand.Create<Enrollee>(AddEnrollee);
        }
        void AddEnrollee(Enrollee enrollee)
        {
            Student student = new();
            student.SurName = enrollee.SurName;
            student.Name = enrollee.Name;
            student.MiddleName = enrollee.MiddleName;
            student.FullName = $"{enrollee.SurName} {enrollee.Name} {enrollee.MiddleName}";
            _deanRoomRepository.CreateStudent(student, Group, _typeGroup, _form, _level, _faculty);
            if (File.Exists(Path.Combine(FileServer.Enrollees, $"{enrollee.SurName}{enrollee.Name}{enrollee.MiddleName}.json")))
            {
                Enrolless.Remove(enrollee);
                File.Delete(Path.Combine(FileServer.Enrollees, $"{enrollee.SurName}{enrollee.Name}{enrollee.MiddleName}.json"));
            }
        }
    }
}