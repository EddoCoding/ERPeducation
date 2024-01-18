using ERPeducation.Common.Interface.DialogModel;
using ERPeducation.Models.AdmissionCampaign.EducationDocuments;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.TabsViewModel.EducationViewModel;

namespace ERPeducation.Common.Services.ServiceForEducation
{
    public class GetDiplomaService : IEducationModelService
    {
        public TypeEducationBaseModel GetModel(object viewModel)
        {
            var diplomaData = (DiplomaViewModel)viewModel;

            string typeDocument = string.Empty;
            switch (diplomaData.TypeEducation)
            {
                case "Диплом о Среднем профессиональном образовании":
                    typeDocument = "Среднее профессиональное";
                    break;
                case "Диплом Бакалавра":
                    typeDocument = "Бакалавриат";
                    break;
                case "Диплом Магистра":
                    typeDocument = "Магистратура";
                    break;
                case "Диплом об окончании Аспирантуры":
                    typeDocument = "Аспирантура";
                    break;
            }

            DiplomaModel diploma = new DiplomaModel()
            {
                TypeEducation = typeDocument,
                TypeEducationDocument = diplomaData.TypeEducationDocument,
                IsBool = diplomaData.IsBool,
                DateOfIssue = diplomaData.DateOfIssue,
                IsPopup = diplomaData.IsPopup,
                IssuedBy = diplomaData.IssuedBy,
                NumberDiploma = diplomaData.NumberDiploma,
                RegistrationNumber = diplomaData.RegistrationNumber,
                Qualification = diplomaData.Qualification,
                AdditionalNumberDiploma = diplomaData.AdditionalNumberDiploma
            };

            return diploma;
        }
    }
}
