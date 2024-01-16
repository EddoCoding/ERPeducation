using ERPeducation.Common.Interface;
using ERPeducation.Models.AdmissionCampaign.Documents;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel;

namespace ERPeducation.Common.Services
{
    public class GetForeignPassportService : IConnectionModelService
    {
        public DocsBase GetModel(object viewModelData)
        {
            var foreignPassportData = (ForeignPassportViewModel)viewModelData;

            ForeignPassport foreignPassport = new ForeignPassport()
            {
                TypeDocument = "Иностранный паспорт",

                Abbreviation = foreignPassportData.Abbreviation,
                Number = foreignPassportData.Number,
                IssuedBy = foreignPassportData.IssuedBy,
                DateOfIssue = foreignPassportData.DateOfIssue,
                Validity = foreignPassportData.Validity,

                SurName = foreignPassportData.SurName,
                Name = foreignPassportData.Name,
                MiddleName = foreignPassportData.MiddleName,
                DateOfBirth = foreignPassportData.DateOfBirth,
                Gender = foreignPassportData.ValueComboBox,
                PlaceOfBirth = foreignPassportData.PlaceOfBirth,
                Citizenship = foreignPassportData.Citizenship
            };

            return foreignPassport;
        }
    }
}
