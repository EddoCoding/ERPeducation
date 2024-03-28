using ERPeducation.Common.Interface;
using ERPeducation.Common.Services;
using ERPeducation.Common.Windows.WindowDocuments;
using ERPeducation.Models;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Enrollee;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    [JsonObject]
    public class AddChangeEnrolleeViewModel : ReactiveObject
    {
        public EnrolleePersonalInfoViewModel epivm { get; set; } //ViewModel или Model Личной информации
        public EnrolleeContactInfoViewModel ecivm { get; set; } //ViewModel или Model Контактной информации
        public EnrolleeEducationViewModel eevm { get; set; } //ViewModel или Model Образования
        public EnrolleeAdmissionViewModel eavm { get; set; } //ViewModel или Model Поступления


        public event Action<AddChangeEnrolleeViewModel>? OnDelete;

        [JsonIgnore] public ReactiveCommand<Unit, Unit> ChangeEnrolleeCommand { get; set; }
        [JsonIgnore] public ReactiveCommand<Unit,Unit> DeleteEnrolleeCommand { get; set; }

        [JsonIgnore] public ReactiveCommand<Unit,Unit> AddEnrolleeCommand { get; set; }


        public ObservableCollection<AddChangeEnrolleeViewModel> enrollees { get; set; }
        public MainTabControl<MainTabItem> data { get; set; }


        IDialogDocument _dialogDocument;
        IJSONService _jsonService;
        public AddChangeEnrolleeViewModel(ObservableCollection<AddChangeEnrolleeViewModel> enrollees, MainTabControl<MainTabItem> data)
        {
            _dialogDocument = new DialogDocument();
            _jsonService = new JSONService();

            this.enrollees = enrollees;
            this.data = data;

            epivm = new EnrolleePersonalInfoViewModel();
            ecivm = new EnrolleeContactInfoViewModel();
            eevm = new EnrolleeEducationViewModel();
            eavm = new EnrolleeAdmissionViewModel();

            ChangeEnrolleeCommand = ReactiveCommand.Create(changeEnrollee);
            DeleteEnrolleeCommand = ReactiveCommand.Create(() =>
            {
                OnDelete?.Invoke(this);
            });

            AddEnrolleeCommand = ReactiveCommand.Create(() =>
            {
                _jsonService.SerializeEnrollee(this);
                enrollees.Add(this);
            });
        }

        void changeEnrollee() => _dialogDocument.OpenWindowChangeEnrollee(this, data);
    }
}