using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class EnrolleeViewModel : ReactiveObject
    {
        public string SurName { get; set; } = "Фамилия";
        public string Name { get; set; } = "Имя";
        public string MiddleName { get; set; } = "Отчество";

        [Reactive] public string SelectValueComboBox { get; set; }
        [Reactive] public bool Popup { get; set; }
        [Reactive] public DateTime DateOfBirth { get; set; }

        [Reactive] public string Citizenship { get; set; }
        [Reactive] public bool IsEnabled{ get; set; } = true;
        [Reactive] public DateTime DoCitizenship { get; set; }



        public ReactiveCommand<Unit,Unit> OpenPopupCommand { get; set; }
        public ReactiveCommand<Unit,Unit> OpenValueCommand { get; set; }
        public ReactiveCommand<Unit,Unit> DelValueCommand { get; set; }


        public EnrolleeViewModel(ObservableCollection<EnrolleeViewModel> enrollees)
        {
            InitializingCommands();
        }

        void InitializingCommands()
        {
            OpenPopupCommand = ReactiveCommand.Create(() =>
            {
                if (!Popup) Popup = true;
                else Popup = false;
            });

            OpenValueCommand = ReactiveCommand.Create(() =>
            {
                IsEnabled = true;
            });

            DelValueCommand = ReactiveCommand.Create(() =>
            {
                Citizenship = string.Empty;
                DoCitizenship = DateTime.MinValue;
                IsEnabled = false;
            });
        }
    }
}