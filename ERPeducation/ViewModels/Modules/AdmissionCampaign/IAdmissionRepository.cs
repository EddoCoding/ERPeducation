using ERPeducation.Models.AdmissionCampaign;
using System.Collections.Generic;

namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public interface IAdmissionRepository
    {
        ICollection<Enrollee> GetEnrollees();
        void CreateEnrollee();
    }
}