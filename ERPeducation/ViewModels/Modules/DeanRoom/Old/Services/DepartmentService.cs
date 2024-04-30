using ERPeducation.Common.Interface;
using ERPeducation.Common.Services;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Old.Services
{
    public class DepartmentService : IEducationalService<TreeViewDepartment>
    {
        public IJSONService jsonService { get; set; } = new JSONService();

    }
}