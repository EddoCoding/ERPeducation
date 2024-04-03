using DynamicData;
using ERPeducation.Common.BD;
using ERPeducation.Common.Command;
using ERPeducation.Common.Interface;
using ERPeducation.Common.Services;
using ERPeducation.Models;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments;
using Newtonsoft.Json;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;
using System.Windows;
using System.Windows.Controls;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class AdmissionCampaignViewModel : ReactiveObject
    {
        public ObservableCollection<AddChangeEnrolleeViewModel> Enrollees { get; set; }

        AddChangeEnrolleeViewModel selectedEnrollee;
        public AddChangeEnrolleeViewModel SelectedEnrollee
        {
            get => selectedEnrollee;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedEnrollee, value);
                _userControlService.GetInfoEnrollee(UserControlEnrollee, SelectedEnrollee);
            }
        }

        public UserControl UserControlEnrollee { get; set; }

        public ReactiveCommand<Unit, Unit> AddChangeEnrolleeCommand { get; set; }
        public ReactiveCommand<Unit, Unit> SearchCommand { get; set; }
        public ReactiveCommand<Unit, Unit> SearchSettingCommand { get; set; }


        IUserControlService _userControlService;
        IJSONService _jsonService;
        public AdmissionCampaignViewModel(IUserControlService userControlService, IJSONService jsonService, MainTabControl<MainTabItem> data)
        {
            _userControlService = userControlService;
            _jsonService = jsonService;

            UserControlEnrollee = new UserControl();

            AddChangeEnrolleeCommand = ReactiveCommand.Create(() =>
            {
                data.TabItem.Add(new MainTabItem("Абитуриент", _userControlService.GetUserControlEnrollee(Enrollees, data)));
            });

            SearchCommand = ReactiveCommand.Create(NotReady.Message);
            SearchSettingCommand = ReactiveCommand.Create(NotReady.Message);

            Enrollees = new ObservableCollection<AddChangeEnrolleeViewModel>();
            Enrollees.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null) foreach (AddChangeEnrolleeViewModel item in e.OldItems) item.OnDelete -= deleteItem;
                if (e.NewItems != null) foreach (AddChangeEnrolleeViewModel item in e.NewItems) item.OnDelete += deleteItem;
            };

            string[] files = Directory.GetFiles(FileServer.Enrollees);
            if (files.Length > 0)
            {
                foreach (var file in files)
                {
                    var enrollee = JsonConvert.DeserializeObject<AddChangeEnrolleeViewModel>(File.ReadAllText(file));
                    enrollee.data = data;

                    enrollee.AddEnrolleeCommand = ReactiveCommand.Create(() =>
                    {
                        _jsonService.SerializeEnrollee(enrollee);
                    });
                    
                    Enrollees.Add(enrollee);
                }
            }
        }

        void deleteItem(AddChangeEnrolleeViewModel enrollee) => Enrollees.Remove(enrollee);
    }
}