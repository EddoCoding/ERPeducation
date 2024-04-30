using ERPeducation.Common.BD;
using ERPeducation.Common.Interface;
using ERPeducation.Common.Windows.AddUser;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace ERPeducation.Common.Services
{
    public class JSONService : IJSONService
    {
        JsonSerializerSettings options = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented
        };

        //СЕРИАЛИЗАЦИЯ\ДОБАВЛЕНИЕ ПОЛЬЗОВАТЕЛЯ В ПАПКУ
        public void CreateFileJson(string fileJson, string fileName, string fullName, string identifier, bool rectorAccess,
            bool deanRoom, bool trainingDivision, bool teacher, bool admissionCampaign, bool administration)
        {
            using(StreamWriter sw = new StreamWriter(Path.Combine(fileJson, fileName))) 
            {
                sw.Write(System.Text.Json.JsonSerializer.Serialize(new UserViewModel($"{fullName}", $"{identifier}", rectorAccess,
                 deanRoom, trainingDivision, teacher, admissionCampaign, administration)));
                sw.Close();
            }
        }

        public UserViewModel GetFileJson(string filePath)
        {
            UserViewModel userModel;
            using(FileStream fs = File.OpenRead(filePath)) userModel = System.Text.Json.JsonSerializer.Deserialize<UserViewModel>(fs);
            return userModel;
        }
        public void GetUserFileJson(ObservableCollection<UserViewModel> users)
        {
            foreach (var filePath in Directory.GetFiles(FileServer.Users))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        UserViewModel userModel = System.Text.Json.JsonSerializer.Deserialize<UserViewModel>(sr.ReadToEnd());
                        users.Add(userModel);
                    }
                }
            }
        }
    }
}