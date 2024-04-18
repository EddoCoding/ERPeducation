using ERPeducation.ViewModels.Modules.TrainingDivision;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.Common.Windows.Syllabus.WindowSettingSyllabus
{
    public class SettingSyllabusViewModel : ReactiveObject
    {
        public ObservableCollection<SemestrVM> Semesters { get; set; }

        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }

        Action closeWindow;

        public SettingSyllabusViewModel(SyllabusVM syllabus, Action closeWindow)
        {
            this.closeWindow = closeWindow;

            Semesters = new ObservableCollection<SemestrVM>();
            foreach(var semestr in syllabus.Semesters)
                Semesters.Add(semestr);

            CloseWindowCommand = ReactiveCommand.Create(Exit);
        }



        void Exit() => closeWindow();


        //public SettingSyllabusViewModel(SyllabusVM syllabus, Action closeWindow) 
        //{
        //    Semesters = new ObservableCollection<SemestrVM>();
        //
        //    foreach(var semestr in syllabus.Semesters)
        //    {
        //        SemestrVM semestrVM = new SemestrVM();
        //        semestrVM.Number = semestr.Number;
        //
        //        foreach(var discipline in semestr.Disciplines)
        //            semestrVM.Disciplines.Add(discipline);
        //
        //        Semesters.Add(semestrVM);
        //    }
        //
        //    this.closeWindow = closeWindow;
        //
        //    CloseWindowCommand = ReactiveCommand.Create(Exit);
        //}
    }
}