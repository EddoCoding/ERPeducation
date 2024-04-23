using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.Old.EducationDocuments
{
    [JsonObject]
    public class EducationMasterViewModel : EducationDocumentBase
    {
        [Reactive] public string RegistrationNumber { get; set; } = string.Empty;
        [Reactive] public string SelectedFormOfStudy { get; set; } = string.Empty;
        [Reactive] public string Series { get; set; } = string.Empty;
        [Reactive] public string Number { get; set; } = string.Empty;
        [Reactive] public string SeriesSupplement { get; set; } = string.Empty;
        [Reactive] public string NumberSupplement { get; set; } = string.Empty;

        public EducationMasterViewModel(ObservableCollection<EducationDocumentBase> education, Action closeWindow)
        {
            TypeEducation = "Магистратура";
            TypeDocument = "Диплом магистра";

            ChangeCommand = ReactiveCommand.Create(Change);
            DeleteCommand = ReactiveCommand.Create(Delete);

            CloseWindowCommand = ReactiveCommand.Create(closeWindow);
            AddDocumentCommand = ReactiveCommand.Create(() =>
            {
                education.Add(this);
                closeWindow();
            });
        }
    }
}
