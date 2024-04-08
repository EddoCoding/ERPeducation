using ERPeducation.Common.Interface;
using ERPeducation.Common.Services;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using System.Collections.Generic;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Services
{
    public interface IEducationalService
    {
        IJSONService jsonService { get; set; }
        IEnumerable<TreeViewFaculty> GetEducationalData();
    }
}