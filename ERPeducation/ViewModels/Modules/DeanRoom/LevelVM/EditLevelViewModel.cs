﻿using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.DeanRoom.LevelVM
{
    public class EditLevelViewModel
    {
        public LvlOfTraining OldNameLevel { get; set; }
        public LvlOfTraining NewNameLevel { get; set; }

        Faculty _selectedFaculty;

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<LvlOfTraining, Unit> EditLevelCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public EditLevelViewModel(IDeanRoomRepository repository, LvlOfTraining level, Faculty faculty, Action closeWindow)
        {
            _repository = repository;
            OldNameLevel = level;
            _selectedFaculty = faculty;
            _closeWindow = closeWindow;

            NewNameLevel = new LvlOfTraining();

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            EditLevelCommand = ReactiveCommand.Create<LvlOfTraining>(EditLevel);
        }

        void Exit() => _closeWindow();
        void EditLevel(LvlOfTraining level)
        {
            NewNameLevel.Forms = level.Forms;
            _repository.EditLevel(level, NewNameLevel, _selectedFaculty);
            _closeWindow();
        }
    }
}