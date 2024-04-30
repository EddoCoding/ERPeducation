using ERPeducation.Common.Interface;
using ERPeducation.Common.Services;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Old.Services
{
    public class FacultyService : IEducationalService<TreeViewFaculty>
    {
        public IJSONService jsonService { get; set; } = new JSONService();

    }
}