using ERPeducation.ViewModels.Modules.TrainingDivision;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.Common.Windows.Syllabus.WindowAddSyllabus
{
    public class AddSyllabusViewModel
    {
        public SyllabusVM Syllabus { get; set; } = new();

        ObservableCollection<SyllabusVM> syllabus;

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<SyllabusVM, Unit> AddSellabusCommand { get; set; }

        Action closeWindow;

        ISyllabus _syllabus;
        public AddSyllabusViewModel(ISyllabus _syllabus, ObservableCollection<SyllabusVM> syllabus, Action closeWindow)
        {
            this._syllabus = _syllabus;
            this.syllabus = syllabus;
            this.closeWindow = closeWindow;

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddSellabusCommand = ReactiveCommand.Create<SyllabusVM>(syllabusVM => AddSellabus(syllabusVM));
        }

        void Exit() => closeWindow();
        void AddSellabus(SyllabusVM syllabusVM)
        {
            var syllabus = new SyllabusVM(syllabusVM.TitleSyllabus, syllabusVM.NumberOfSemester);

            _syllabus.SerializationSyllabus(syllabus);

            closeWindow();
        }
    }
}