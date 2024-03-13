using ERPeducation.Common.Interface;
using ERPeducation.Common.Services;
using System.IO;
using System.Windows.Forms;

namespace ERPeducation.Common.BD
{
    public class DirectoryFile : IDirectoryFile
    {
        public string CreateBase()
        {
            IJSONService jsonService = new JSONService();

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();

            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems"));

            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "Administration"));

            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "Administration", "Users"));

            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "Administration", "Structures"));
            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "Administration", "Structures", "About"));
            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "Administration", "Structures", "EducationalStructure"));
            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "Administration", "Structures", "Education"));
            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "Administration", "Structures", "SpaceManagement"));

            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "Administration", "DocumentManagement"));
            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "Administration", "AdmissionsCampaignManagement"));

            FileServer.PathIS = dialog.SelectedPath;

            jsonService.CreateFileJson(FileServer.Users, "AdminAdmin.json", "Администратор", "AdminAdmin", true, true, true, true, true, true);

            return FileServer.PathIS;
        }
    }
}
