using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign.EducationDocuments
{
    [JsonObject]
    public class BasicGeneralEducationViewModel : EducationDocumentBase
    {
        [Reactive] public string CodeSeriesNumber { get; set; } = string.Empty;

        public BasicGeneralEducationViewModel(ObservableCollection<EducationDocumentBase> education, Action closeWindow) 
        {
            TypeEducation = "Основное общее образование";
            TypeDocument = "Аттестат об основном общем образовании";

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