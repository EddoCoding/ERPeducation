using ERPeducation.ViewModels.Modules.Administration;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.Common
{
    public class NotificationViewModel : ReactiveObject
    {
        public ReactiveCommand<Unit, Unit> DeleteCommand { get; set; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; set; }

        public NotificationViewModel(AdministrationStructViewModel viewModel, Action closeWindow)
        {
            DeleteCommand = ReactiveCommand.Create(() => 
            {
                viewModel.DeleteTreeViewItem();
                closeWindow();
            });

            CancelCommand = ReactiveCommand.Create(closeWindow);
        }
    }
}