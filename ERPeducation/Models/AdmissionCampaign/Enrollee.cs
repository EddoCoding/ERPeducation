using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;

namespace ERPeducation.Models.AdmissionCampaign
{
    [JsonObject]
    public class Enrollee : ReactiveObject
    {
        [Reactive] public string SurName { get; set; } = string.Empty;        // -- Фамилия --
        [Reactive] public string Name { get; set; } = string.Empty;           // -- Имя --
        [Reactive] public string MiddleName { get; set; } = string.Empty;     // -- Отчество --
        [Reactive] public string Gender { get; set; } = string.Empty;         // -- Пол --
        [Reactive] public DateTime DateOfBirth { get; set; }                  // -- Дата рождения --
        [Reactive] public string Citizenship { get; set; } = string.Empty;    // -- Гражданство --
        [Reactive] public DateTime DateCitizenship { get; set; }              // -- Действует до --
    }
}