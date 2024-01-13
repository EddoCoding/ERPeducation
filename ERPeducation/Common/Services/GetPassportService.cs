using ERPeducation.Common.Interface;
using ERPeducation.Models.AdmissionCampaign.Documents;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.DocumentsViewModel;

namespace ERPeducation.Common.Services
{
    public class GetPassportService : IConnectionModelService
    {
        public DocsBase GetModelDocument(object viewModelData)
        {
            var passportData = (PassportViewModel)viewModelData;

            Passport passport = new Passport()
            {
                TypeDocument = "Паспорт",

                IssuedBy = passportData.IssuedBy,
                DateOfIssue = passportData.DateOfIssue,
                DepartmentCode = passportData.DepartmentCode,
                SeriesNumber = passportData.SeriesNumber,

                SurName = passportData.SurName,
                Name = passportData.Name,
                MiddleName = passportData.MiddleName,
                Gender = passportData.ValueComboBox,
                DateOfBirth = passportData.DateOfBirth,
                PlaceOfBirth = passportData.PlaceOfBirth,

                Location = passportData.Location,
                City = passportData.City,
                Street = passportData.Street,
                HouseNumber = passportData.HouseNumber,
                Frame = passportData.Frame,
                ApartmentNumber = passportData.ApartmentNumber
            };

            return passport;
        }
    }
}
