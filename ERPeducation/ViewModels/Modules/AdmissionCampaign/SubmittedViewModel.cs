using ERPeducation.Common.Interface;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class SubmittedViewModel : ISubmitted
    {
        public string SelectedSubmitted { get; set; }
        [Reactive] public string SelectedSee { get; set; }
        [Reactive] public int Quantity { get; set; }


        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<Unit,Unit> AddSubmittedCommand { get; set; }

        public SubmittedViewModel(ObservableCollection<ISubmitted> submitted, Action closeWindow)
        {
            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddSubmittedCommand = ReactiveCommand.Create(() =>
            {
                submitted.Add(this);
                closeWindow();
            });
        }
    }
}