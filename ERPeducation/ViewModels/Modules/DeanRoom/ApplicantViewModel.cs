using DynamicData;
using ERPeducation.Models.AdmissionCampaign;
using ERPeducation.Models.DeanRoom;
using ERPeducation.ViewModels.Modules.DeanRoom.Repository;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.DeanRoom
{
    public class ApplicantViewModel : ReactiveObject
    {
        string _direction;
        public string Direction
        {
            get => _direction;
            set
            {
                this.RaiseAndSetIfChanged(ref _direction, value);
                if (_direction != null)
                {
                    Enrollees.Clear();
                    _repositotyDirections.GetEnrollees(_direction);
                }
            }
        }
        public ObservableCollection<string> Directions { get; set;}
        public ObservableCollection<Enrollee> Enrollees { get; set;}

        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }

        Action _closeWindow;

        IApplicantDirectionRepository _repositotyDirections;
        public ApplicantViewModel(IApplicantDirectionRepository repositotyDirections, Action closeWindow)
        {
            _repositotyDirections = repositotyDirections;
            _closeWindow = closeWindow;

            Directions = new ObservableCollection<string>();
            Enrollees = new();
            repositotyDirections.Directions.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) Directions.Add(e.NewItems[0] as string);
            };
            repositotyDirections.DirectionEnrollees.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add) Enrollees.Add(e.NewItems[0] as Enrollee);
            };
            repositotyDirections.GetDirections();

            CloseWindowCommand = ReactiveCommand.Create(Exit);
        }

        void Exit() => _closeWindow();
    }
}