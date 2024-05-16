using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.DeanRoom.LevelVM
{
    public class EditLevelViewModel
    {
        public LvlOfTraining OldNameLevel { get; set; }
        public LvlOfTraining NewNameLevel { get; set; } = new LvlOfTraining();

        public Faculty SelectedFaculty { get; set; }

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<LvlOfTraining, Unit> EditLevelCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public EditLevelViewModel(IDeanRoomRepository repository, LvlOfTraining level, Faculty faculty, Action closeWindow)
        {
            _repository = repository;
            OldNameLevel = level;
            SelectedFaculty = faculty;
            _closeWindow = closeWindow;

            NewNameLevel.NameLevel = level.NameLevel;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            EditLevelCommand = ReactiveCommand.Create<LvlOfTraining>(EditLevel);
        }

        void Exit() => _closeWindow();
        void EditLevel(LvlOfTraining level)
        {
            if (NewNameLevel.NameLevel == OldNameLevel.NameLevel)
            {
                _closeWindow();
                return;
            }

            NewNameLevel.Forms = level.Forms;
            NewNameLevel.TitleFaculty = level.TitleFaculty;
            EditNesting();

            _repository.EditLevel(level, NewNameLevel, SelectedFaculty);
            _closeWindow();
        }

        void EditNesting()
        {
            if (NewNameLevel.Forms != null)
                foreach (var form in NewNameLevel.Forms)
                {
                    form.TitleLevel = NewNameLevel.NameLevel;
                    if (form.TypeGroups != null)
                        foreach (var typeGroup in form.TypeGroups)
                        {
                            typeGroup.TitleLevel = NewNameLevel.NameLevel;
                            if (typeGroup.Groups != null)
                                foreach (var group in typeGroup.Groups)
                                {
                                    group.TitleLevel = NewNameLevel.NameLevel;
                                    if (group.Students != null)
                                        foreach (var student in group.Students)
                                            student.TitleLevel = NewNameLevel.NameLevel;
                                }
                        }
                }
        }
    }
}