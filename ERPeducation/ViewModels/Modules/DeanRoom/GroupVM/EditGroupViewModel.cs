using ERPeducation.Models;
using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ERPeducation.ViewModels.Modules.TrainingDivision.ScheduleVM;
using ERPeducation.ViewModels.Modules.TrainingDivision.Service;
using ERPeducation.Views.DeanRoom.WindowGroup;
using ERPeducation.Views.TrainingDivision;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Windows;

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
        [Reactive] public Syllabus SelectedSyllabus { get; set; } = new();

        #region Команды
        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Group, Unit> EditGroupCommand { get; set; }
        public ReactiveCommand<Syllabus, Unit> ShowInfoSyllabusCommand { get; set; }
        public ReactiveCommand<Unit, Unit> ShowInfoScheduleCommand { get; set; }
        public ReactiveCommand<Unit, Unit> ShowAcademicPerformanceCommand { get; set; }
        #endregion

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public EditGroupViewModel(IDeanRoomRepository repository, Group group, TypeGroup typeGroup, FormsOfTraining selectedForm, 
               LvlOfTraining selectedLevel, Faculty selectedFaculty, Action closeWindow)
        {
            _repository = repository;
            OldGroup = group;
            SelectedForm = selectedForm;
            SelectedLevel = selectedLevel;
            SelectedFaculty = selectedFaculty;
            SelectedTypeGroup = typeGroup;
            _closeWindow = closeWindow;
            
            SelectedSyllabus.TitleSyllabus = group.Syllabus;

            NewGroup.NameGroup = group.NameGroup;
            NewGroup.Direction = group.Direction;

            foreach (var syllabus in repository.GetSyllabus()) Syllabus.Add(syllabus);

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            EditGroupCommand = ReactiveCommand.Create<Group>(EditGroup);
            ShowInfoSyllabusCommand = ReactiveCommand.Create<Syllabus>(ShowInfoSyllabus);
            ShowInfoScheduleCommand = ReactiveCommand.Create(ShowInfoSchedule);
            ShowAcademicPerformanceCommand = ReactiveCommand.Create(ShowAcademicPerformance);
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
            NewGroup.Syllabus = SelectedSyllabus.TitleSyllabus;
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

        void ShowInfoSyllabus(Syllabus syllabus)
        {
            ISyllabusService service = new SyllabusService();
            service.OpenWindowShowSyllalbus(syllabus, OldGroup);
        }
        void ShowInfoSchedule()
        {
            ShowScheduleWindow windowSchedule = new();
            windowSchedule.DataContext = new ShowScheduleViewModel(OldGroup.Schedule, windowSchedule.Close);
            windowSchedule.ShowDialog();
        } //-- Вынести окно в сервис --
        void ShowAcademicPerformance() 
        {
            AcademicPerformanceWindow window = new();
            window.DataContext = new AcademicPerformanceViewModel(OldGroup, window.Close);
            window.ShowDialog();
        } //-- Вынести окно в сервис --
    }
}
