using ERPeducation.Common.Interface;
using ERPeducation.Models.Administration;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ERPeducation.Common.Services
{
    public class FileService : IFileService
    {
        public void GetFaculties(ObservableCollection<StructTreeViewItem> TreeViewItems)
        {
            foreach (string filePath in Directory.GetFiles(PathDirectory.folderPath, "*.txt"))
            {
                var newItem = new StructTreeViewItem(new FileService()) { Header = Path.GetFileNameWithoutExtension(filePath) };

                foreach (string line in File.ReadAllLines(filePath))
                    newItem.Items.Add(new DepartmentTreeViewItem() { Header = line });

                TreeViewItems.Add(newItem);
            }
        }
        public void ConfigureStruct(ObservableCollection<StructTreeViewItem> TreeViewItems)
        {
            for (int i = 0; i < TreeViewItems.Count; i++)
            {
                using (StreamWriter writer = new StreamWriter(File.Create(Path.Combine(PathDirectory.folderPath, $"{TreeViewItems[i].Header}.txt"))))
                {
                    for (int w = 0; w < TreeViewItems[i].Items.Count; w++)
                    {
                        writer.WriteLine(TreeViewItems[i].Items[w].Header);
                    }
                }
            }
        }
        public void DeleteTreeViewItem(object treeViewItem)
        {
            if (treeViewItem is StructTreeViewItem treeViewItemStruct)
            {
                try
                {
                    foreach (string file in Directory.GetFiles(PathDirectory.folderPath, $"{treeViewItemStruct.Header}.txt", SearchOption.AllDirectories))
                    {
                        if (Path.GetFileName(file) == $"{treeViewItemStruct.Header}.txt")
                        {
                            File.Delete(file);
                            break;
                        }
                    }
                }
                catch
                {
                    //ОБРАБОТЬ ИСКЛЮЧЕНИЯ В ДРУГОМ СЕРВИСЕ
                }
            }
            else if(treeViewItem is DepartmentTreeViewItem treeViewItemDepartment)
            {
                try
                {
                    List<string> lines = new List<string>(File.ReadAllLines(PathDirectory.folderPath));

                    lines.RemoveAll(line => line == treeViewItemDepartment.Header);

                    File.WriteAllLines(PathDirectory.folderPath, lines);
                }
                catch
                {
                    //ОБРАБОТЬ ИСКЛЮЧЕНИЯ В ДРУГОМ СЕРВИСЕ
                }
            }
            //ОБРАБОТЬ ИСКЛЮЧЕНИЯ В ДРУГОМ СЕРВИСЕ
        }//ОБРАБОТЬ ИСКЛЮЧЕНИЯ В ДРУГОМ СЕРВИСЕ
        //ОБРАБОТЬ ИСКЛЮЧЕНИЯ В ДРУГОМ СЕРВИСЕ
    }
}