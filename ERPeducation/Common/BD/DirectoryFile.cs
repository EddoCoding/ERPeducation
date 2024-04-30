using ERPeducation.Common.Interface;
using ERPeducation.Common.Services;
using System.IO;
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

            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "AdmissionCampaign")); 
            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "AdmissionCampaign", "Enrollees")); 

            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "TrainingDivision"));
            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "TrainingDivision", "Syllabus"));
            Directory.CreateDirectory(Path.Combine(dialog.SelectedPath, "InformationSystems", "TrainingDivision", "Schedule"));

            FileServer.PathIS = dialog.SelectedPath;



            //Добавление администратора - потом переделать, чтобы не создавался сам
            //т.е. вход в систему будет свободен сразу без пользователей
            //т.е. будет проверка происходить есть пользовати в ИС и если есть показать авторизацию, нет - войти
            //но в таком случае будет работать только модуль -- Администрирование --
            jsonService.CreateFileJson(FileServer.Users, "AdminAdmin.json", "Администратор", "AdminAdmin", true, true, true, true, true, true);



            return FileServer.PathIS;
        }
    }
}