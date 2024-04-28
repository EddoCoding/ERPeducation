using ReactiveUI;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Services
{
    public class DirectionService : ReactiveObject, IDirectionService
    {
        //КАК СДЕЛАЮ И ПЕРЕДЕЛАЮ МОДУЛЬ ДЕКАНАТ -- ПРОДОЛЖИТЬ ЗДЕСЬ --

        ObservableCollection<string> _directions;                                      //Поменять тип когда будет известен
        public ObservableCollection<string> Directions
        {
            get => _directions;
            set => this.RaiseAndSetIfChanged(ref _directions, value);
        }                              //Поменять тип когда будет известен

        public DirectionService() => Directions = new ObservableCollection<string>();  //Поменять тип когда будет известен

        public void GetDirections()
        {
            //Сделать метод когда будет сделана иерархия для деканата и сам деканат
            //Иерархия -- Уровень подготовки -- Форма подготовки -- Направление подготовки --
        }
    }
}
