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
        // -- Личная информация --
        [Reactive] public string SurName { get; set; } = string.Empty;        // -- Фамилия --
        [Reactive] public string Name { get; set; } = string.Empty;           // -- Имя --
        [Reactive] public string MiddleName { get; set; } = string.Empty;     // -- Отчество --
        [Reactive] public string Gender { get; set; } = string.Empty;         // -- Пол --
        [Reactive] public DateTime DateOfBirth { get; set; }                  // -- Дата рождения --
        [Reactive] public string Citizenship { get; set; } = string.Empty;    // -- Гражданство --
        [Reactive] public DateTime DateCitizenship { get; set; }              // -- Действует до --

        // -- Контактная информация --
        [Reactive] public string ResidenceAddress { get; set; } = string.Empty;
        [Reactive] public string RegistrationAddress { get; set; } = string.Empty;
        [Reactive] public string HomePhone { get; set; } = string.Empty;
        [Reactive] public string MobilePhone { get; set; } = string.Empty;


        ObservableCollection<DocumentBase> _documents;
        public ObservableCollection<DocumentBase> Documents
        {
            get => _documents;
            set => this.RaiseAndSetIfChanged(ref _documents, value);
        }                // -- Коллекция персональных документов --

        ObservableCollection<EducationBase> _educations;
        public ObservableCollection<EducationBase> Educations
        {
            get => _educations;
            set => this.RaiseAndSetIfChanged(ref _educations, value);
        }              // -- Коллекция документов об образовании --

        ObservableCollection<DirectionOfAdmission> _directions;
        public ObservableCollection<DirectionOfAdmission> Directions
        {
            get => _directions;
            set => this.RaiseAndSetIfChanged(ref _directions, value);
        }       // -- Коллекция выбранных направлений подготовки --

        public DirectionOfAdmission SelectedDirection => Directions[0];       // -- Выбранное направление --

        public Enrollee()
        {
            Documents = new ObservableCollection<DocumentBase>();
            Educations = new ObservableCollection<EducationBase>();
            Directions = new ObservableCollection<DirectionOfAdmission>();
        }
    }
}