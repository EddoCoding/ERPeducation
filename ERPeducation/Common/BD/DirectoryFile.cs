using ERPeducation.Common.Interface;
using ERPeducation.Common.Services;
using ERPeducation.ViewModels.Modules.Administration.Struct.Education;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace ERPeducation.Common.BD
{
    public class DirectoryFile : IDirectoryFile
    {
        IJSONService jsonService = new JSONService();

        public string CreateBase()
        {
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

            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "AdmissionCampaign"));
            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "AdmissionCampaign", "Enrollees"));

            FileServer.PathIS = dialog.SelectedPath;

            jsonService.CreateFileJson(FileServer.Users, "AdminAdmin.json", "Администратор", "AdminAdmin", true, true, true, true, true, true);

            return FileServer.PathIS;
        }

        public void CreateFileBase()
        {
            using (FileStream fs = new FileStream(FileServer.structPathFaculty, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(JsonSerializer.Serialize(new ObservableCollection<TreeViewFacultyItemOne>()
                    {
                        new TreeViewFacultyItemOne("Факультеты")
                    }));
                }
            }
            using (FileStream fs = new FileStream(FileServer.structPathEducation, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(JsonSerializer.Serialize(new ObservableCollection<TreeViewLvlOne>()
                    {
                        new TreeViewLvlOne("Уровни подготовки")
                    }));
                }
            }
        }
    }
}
