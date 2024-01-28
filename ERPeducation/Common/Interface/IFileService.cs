using ERPeducation.Models.Administration;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.Interface
{
    public interface IFileService
    {
        public void GetFaculties(ObservableCollection<StructTreeViewItem> TreeViewItems);
        public void ConfigureStruct(ObservableCollection<StructTreeViewItem> TreeViewItems);
        public void DeleteTreeViewItem(object treeViewItem);
    }
}
