using ERPeducation.ViewModels.Modules.Administration.Struct;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Interface
{
    public interface IJSONService
    {
        public void GetTreeViewLvlItem(ObservableCollection<TreeViewLvlOne> treeViewCollection);
    }
}
