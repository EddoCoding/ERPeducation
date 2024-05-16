using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System.Reactive;
using System;
using ERPeducation.Models;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using ERPeducation.ViewModels.Modules.TrainingDivision.Service;

namespace ERPeducation.ViewModels.Modules.DeanRoom.GroupVM
{
    public class EditGroupViewModel : ReactiveObject
    {
        public Group OldGroup { get; set; }
        public Group NewGroup { get; set; } = new Group();

        public Faculty SelectedFaculty { get; set; }
        public LvlOfTraining SelectedLevel { get; set; }
        public FormsOfTraining SelectedForm { get; set; }
        public TypeGroup SelectedTypeGroup { get; set; }

        public ICollection<Syllabus> Syllabus { get; set; } = new List<Syllabus>();
        [Reactive] public Syllabus SelectedSyllabus { get; set; }

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Group, Unit> EditGroupCommand { get; set; }
        public ReactiveCommand<Syllabus, Unit> ShowInfoSyllabusCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public EditGroupViewModel(IDeanRoomRepository repository, Group group, TypeGroup typeGroup, FormsOfTraining selectedForm, LvlOfTraining selectedLevel, Faculty selectedFaculty, Action closeWindow)
        {
            _repository = repository;
            OldGroup = group;
            SelectedForm = selectedForm;
            SelectedLevel = selectedLevel;
            SelectedFaculty = selectedFaculty;
            SelectedTypeGroup = typeGroup;
            _closeWindow = closeWindow;
            
            SelectedSyllabus = group.Syllabus;

            NewGroup.NameGroup = group.NameGroup;
            NewGroup.Direction = group.Direction;

            foreach (var syllabus in repository.GetSyllabus()) Syllabus.Add(syllabus);

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            EditGroupCommand = ReactiveCommand.Create<Group>(EditGroup);
            ShowInfoSyllabusCommand = ReactiveCommand.Create<Syllabus>(ShowInfoSllabus);
        }

        void Exit() => _closeWindow();
        void EditGroup(Group group)
        {
            if (NewGroup.NameGroup == OldGroup.NameGroup && NewGroup.Direction == OldGroup.Direction)
            {
                _closeWindow();
                return;
            }

            NewGroup.Students = group.Students;
            NewGroup.TitleFaculty = group.TitleFaculty;
            NewGroup.TitleLevel = group.TitleLevel;
            NewGroup.TitleForm = group.TitleForm;
            NewGroup.TitleTypeGroup = group.TitleTypeGroup;
            NewGroup.Syllabus = SelectedSyllabus;
            EditNesting();

            _repository.EditGroup(group, NewGroup, SelectedTypeGroup, SelectedForm, SelectedLevel, SelectedFaculty);
            _closeWindow();
        }
        void EditNesting()
        {
            if (NewGroup.Students != null)
                foreach (var student in NewGroup.Students)
                {
                    student.TitleGroup = NewGroup.NameGroup;
                    student.TitleDirection = NewGroup.Direction;
                }
        }

        void ShowInfoSllabus(Syllabus syllabus)
        {
            ISyllabusService service = new SyllabusService();
            service.OpenWindowShowSyllalbus(syllabus, OldGroup);
        }
    }
}
