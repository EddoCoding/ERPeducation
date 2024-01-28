using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.Administration.StructEducationViewModel
{
    public class StructEducationViewModel : ReactiveObject
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string AdditionalText { get; set; }

        public ReactiveCommand<Unit, Unit> AddCommand { get; set; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; set; }

        public StructEducationViewModel(ObservableCollection<string> structEducation, Action closeWindow) 
        {
            AddCommand = ReactiveCommand.Create(() => 
            {
                structEducation.Add(Text);
                closeWindow();
            });
            CancelCommand = ReactiveCommand.Create(closeWindow);
        }
    }
}
