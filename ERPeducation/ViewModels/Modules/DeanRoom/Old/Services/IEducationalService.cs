using ERPeducation.Common.Interface;
using ERPeducation.ViewModels.Modules.Administration.Struct;
using System.Collections.Generic;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Old.Services
{
    public interface IEducationalService<T>
    {
        IJSONService jsonService { get; set; }
        IEnumerable<T> GetEducationalData(TreeViewBaseClass treeView = default);
    }
}