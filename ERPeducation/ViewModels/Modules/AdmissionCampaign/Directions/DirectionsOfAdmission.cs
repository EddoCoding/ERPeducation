using ReactiveUI;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Directions
{
    public class DirectionsOfAdmission : ReactiveObject
    {
        public string LevelOfTraining { get; set; } = string.Empty;
        public string DirectionOfTraining { get; set; } = string.Empty;
        public string FormOfDirection { get; set; } = string.Empty;
    }
}