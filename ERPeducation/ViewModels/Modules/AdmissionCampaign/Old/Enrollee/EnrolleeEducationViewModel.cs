using ERPeducation.Common.Windows.WindowEducation;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Old.EducationDocuments;
using Newtonsoft.Json;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows.Controls;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Old.Enrollee
{
    [JsonObject]
    public class EnrolleeEducationViewModel : ReactiveObject
    {
        public ObservableCollection<EducationDocumentBase> Educations { get; set; }

        EducationDocumentBase selectedEducation;
        [JsonIgnore]
        public EducationDocumentBase SelectedEducation
        {
            get => selectedEducation;
            set
            {
                selectedEducation = value;
                _dialogEducation.GetUserControlEducation(UserControlEducation, SelectedEducation);
            }
        }

        [JsonIgnore] public UserControl UserControlEducation { get; set; }

        [JsonIgnore] public ReactiveCommand<string, Unit> AddEducationCommand { get; set; }


        IDialogEducation _dialogEducation;
        public EnrolleeEducationViewModel()
        {
            _dialogEducation = new DialogEducation();

            Educations = new ObservableCollection<EducationDocumentBase>();
            Educations.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null) foreach (EducationDocumentBase item in e.OldItems) item.OnDelete -= deleteEducation;
                if (e.NewItems != null) foreach (EducationDocumentBase item in e.NewItems) item.OnDelete += deleteEducation;
            };

            UserControlEducation = new UserControl();

            AddEducationCommand = ReactiveCommand.Create<string>(parameter =>
            {
                switch (parameter)
                {
                    case "9":
                        _dialogEducation.GetBasicGeneral(Educations);
                        break;
                    case "11":
                        _dialogEducation.GetBasicAverage(Educations);
                        break;
                    case "SPO":
                        _dialogEducation.GetSpo(Educations);
                        break;
                    case "Undergraduate":
                        _dialogEducation.GetUndergraduate(Educations);
                        break;
                    case "Master":
                        _dialogEducation.GetMaster(Educations);
                        break;
                    case "Specialty":
                        _dialogEducation.GetSpecialty(Educations);
                        break;
                }
            });
        }

        void deleteEducation(EducationDocumentBase education) => Educations.Remove(education);
    }
}
