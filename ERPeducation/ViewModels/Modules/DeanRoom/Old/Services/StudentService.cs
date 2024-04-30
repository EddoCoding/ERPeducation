using ERPeducation.Common.Interface;
using ERPeducation.Common.Services;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Old.Services
{
    public class StudentService : IEducationalService<TreeViewStudent>
    {
        public IJSONService jsonService { get; set; } = new JSONService();
    }
}