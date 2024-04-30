using ERPeducation.Common.Interface;
using ERPeducation.Common.Services;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Old.Services
{
    public class GroupService : IEducationalService<TreeViewGroup>
    {
        public IJSONService jsonService { get; set; } = new JSONService();
    }

}
