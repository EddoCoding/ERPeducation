using ERPeducation.Models.AdmissionCampaign.Direction;
using ERPeducation.Models.AdmissionCampaign.Educations;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents;
using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;

namespace ERPeducation.Models.AdmissionCampaign
{
    [JsonObject]
    public class Enrollee : ReactiveObject
    {
        // -- Блок личной информации --
        [Reactive] public string SurName { get; set; } = string.Empty;       
        [Reactive] public string Name { get; set; } = string.Empty;          
        [Reactive] public string MiddleName { get; set; } = string.Empty;    
        [Reactive] public string Gender { get; set; } = string.Empty;        
        [Reactive] public DateTime DateOfBirth { get; set; }                 
        [Reactive] public string Citizenship { get; set; } = string.Empty;   
        [Reactive] public DateTime DateCitizenship { get; set; }             

        // -- Блок контактной информации --
        [Reactive] public string ResidenceAddress { get; set; } = string.Empty;
        [Reactive] public string RegistrationAddress { get; set; } = string.Empty;
        [Reactive] public string HomePhone { get; set; } = string.Empty;
        [Reactive] public string MobilePhone { get; set; } = string.Empty;

        // -- Коллекция персональных документов --
        ObservableCollection<DocumentBase> _documents;
        public ObservableCollection<DocumentBase> Documents
        {
            get => _documents;
            set => this.RaiseAndSetIfChanged(ref _documents, value);
        }

        // -- Коллекция документов об образовании --
        ObservableCollection<EducationBase> _educations;
        public ObservableCollection<EducationBase> Educations
        {
            get => _educations;
            set => this.RaiseAndSetIfChanged(ref _educations, value);
        }

        // -- Коллекция выбранных направлений подготовки --
        ObservableCollection<DirectionOfAdmission> _directions;
        public ObservableCollection<DirectionOfAdmission> Directions
        {
            get => _directions;
            set => this.RaiseAndSetIfChanged(ref _directions, value);
        }

        // -- Выбранное направление --
        public DirectionOfAdmission SelectedDirection => Directions[0];       

        public Enrollee()
        {
            Documents = new ObservableCollection<DocumentBase>();
            Educations = new ObservableCollection<EducationBase>();
            Directions = new ObservableCollection<DirectionOfAdmission>();
        }
    }
}