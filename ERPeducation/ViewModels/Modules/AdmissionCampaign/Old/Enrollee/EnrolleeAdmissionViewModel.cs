using ERPeducation.Common.Windows.WindowDirection;
using Newtonsoft.Json;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows.Controls;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Old.Enrollee
{
    [JsonObject]
    public class EnrolleeAdmissionViewModel : ReactiveObject
    {
        public ObservableCollection<DirectionViewModel> Directions { get; set; }

        DirectionViewModel selectedDirection;
        [JsonIgnore]
        public DirectionViewModel SelectedDirection
        {
            get => selectedDirection;
            set
            {
                selectedDirection = value;
                _dialogDirection.GetUserControlDirection(UserControlDirection, SelectedDirection);
            }
        }

        [JsonIgnore] public UserControl UserControlDirection { get; set; }

        [JsonIgnore] public ReactiveCommand<Unit, Unit> AddDirection { get; set; }


        IDialogDirection _dialogDirection;
        public EnrolleeAdmissionViewModel()
        {
            _dialogDirection = new DialogDirection();

            Directions = new ObservableCollection<DirectionViewModel>();
            Directions.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null) foreach (DirectionViewModel item in e.OldItems) item.OnDelete -= deleteDirection;
                if (e.NewItems != null) foreach (DirectionViewModel item in e.NewItems) item.OnDelete += deleteDirection;
            };
            UserControlDirection = new UserControl();

            AddDirection = ReactiveCommand.Create(() =>
            {
                _dialogDirection.GetDirection(Directions);
            });
        }

        void deleteDirection(DirectionViewModel direction) => Directions.Remove(direction);
    }
}