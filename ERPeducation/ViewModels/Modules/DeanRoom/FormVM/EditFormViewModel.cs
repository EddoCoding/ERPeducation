﻿using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using System.Reactive;
using System;

namespace ERPeducation.ViewModels.Modules.DeanRoom.FormVM
{
    public class EditFormViewModel : ReactiveObject
    {
        public FormsOfTraining OldNameForm { get; set; }
        public FormsOfTraining NewNameForm { get; set; } = new FormsOfTraining();

        public LvlOfTraining SelectedLevel { get; set; }
        public Faculty SelectedFaculty { get; set; }

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<FormsOfTraining, Unit> EditFormCommand { get; set; }

        Action _closeWindow;

        IDeanRoomRepository _repository;
        public EditFormViewModel(IDeanRoomRepository repository, FormsOfTraining form, LvlOfTraining level, Faculty faculty, Action closeWindow)
        {
            _repository = repository;
            OldNameForm = form;
            SelectedLevel = level;
            SelectedFaculty = faculty;
            _closeWindow = closeWindow;

            NewNameForm.NameForm = form.NameForm;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            EditFormCommand = ReactiveCommand.Create<FormsOfTraining>(EditForm);
        }

        void Exit() => _closeWindow();
        void EditForm(FormsOfTraining form)
        {
            if (NewNameForm.NameForm == OldNameForm.NameForm)
            {
                _closeWindow();
                return;
            }

            NewNameForm.TypeGroups = form.TypeGroups;
            NewNameForm.TitleFaculty = form.TitleFaculty;
            NewNameForm.TitleLevel = form.TitleLevel;
            EditNesting();

            _repository.EditForm(form, NewNameForm, SelectedLevel, SelectedFaculty);
            _closeWindow();
        }

        void EditNesting()
        {
            if (NewNameForm.TypeGroups != null)
                foreach (var typeGroup in NewNameForm.TypeGroups)
                {
                    typeGroup.TitleForm = NewNameForm.NameForm;
                    if (typeGroup.Groups != null)
                        foreach (var group in typeGroup.Groups)
                        {
                            group.TitleForm = NewNameForm.NameForm;
                            if (group.Students != null)
                                foreach (var student in group.Students)
                                    student.TitleForm = NewNameForm.NameForm;
                        }
                }
        }
    }
}
