using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.EducationDocuments
{
    [JsonObject]
    public class BasicAverageEducationViewModel : EducationDocumentBase
    {
        [Reactive] public string CodeSeriesNumber { get; set; } = string.Empty;

        public BasicAverageEducationViewModel(ObservableCollection<EducationDocumentBase> education, Action closeWindow)
        {
            TypeEducation = "Среднее общее образование";
            TypeDocument = "Аттестат о среднем общем образовании";

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
