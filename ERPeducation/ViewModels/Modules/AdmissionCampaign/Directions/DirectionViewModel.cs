using ERPeducation.ViewModels.Modules.AdmissionCampaign.Services;
using ReactiveUI;
using System;
using System.Reactive;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Directions
{
    public class DirectionViewModel : ReactiveObject
    {
        public DirectionsOfAdmission Direction { get; set; } = new();

        //Сделать свойства для ComboBox's -- Коллекции -- Выбранные элементы --

        Action closeWindow;

        public ReactiveCommand<Unit,Unit> CloseWindowCommand { get; set; }
        public ReactiveCommand<DirectionsOfAdmission, Unit> AddDirectionCommand { get; set; }

        IDirectionService _directionService = new DirectionService(); // -- Переименовать в репозиторий и вернуться к нему как будет готова иерархися и деканат
        IEnrolleeRepository _repository;
        public DirectionViewModel(IEnrolleeRepository repository, Action closeWindow)
        {
            _repository = repository;
            this.closeWindow = closeWindow;

            //Тут в коллекцию получить данные для отображения в ComboBox

            CloseWindowCommand = ReactiveCommand.Create(Exit);
            AddDirectionCommand = ReactiveCommand.Create<DirectionsOfAdmission>(AddDirection);
        }

        void Exit() => closeWindow();
        void AddDirection(DirectionsOfAdmission direction)
        {
            _repository.CreateDirection(direction);
            closeWindow();
        }
    }
}
