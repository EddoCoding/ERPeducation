using ERPeducation.Common.Interface;
using ERPeducation.ViewModels.Modules.Administration.Struct;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using System.Collections.Generic;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Services
{
    public interface IEducationalService<T>
    {
        IJSONService jsonService { get; set; }
        IEnumerable<T> GetEducationalData(TreeViewBaseClass treeView = default);
    }
}