using ERPeducation.Common.BD;
using ERPeducation.Common.Interface;
using ERPeducation.Common.Windows.AddUser;
using ERPeducation.ViewModels.Modules.Administration.Struct.Education;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Old;
using Newtonsoft.Json;
using System;
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

        //КОНФИГУРАЦИЯ ФАКУЛЬТЕТОВ И КАФЕДР
        public void CreateFacultyFileJson(string filePath, ObservableCollection<TreeViewMain> collection)
        {
            using (StreamWriter sw = new StreamWriter(filePath)) sw.Write(JsonConvert.SerializeObject(collection, options));
        }
        //КОНФИГУРАЦИЯ ОБРАЗОВАТЕЛЬНОЙ СТРУКТУРЫ (УРОВНИ, НАПРАВЛЕНИЯ, ФОРМЫ)
        public void CreateEducationFileJson(string filePath, ObservableCollection<TreeViewLvlOne> collection)
        {
            using (StreamWriter sw = new StreamWriter(filePath)) sw.Write(JsonConvert.SerializeObject(collection, options));
        } 


        public void GetTreeViewFacultyItem(ObservableCollection<TreeViewMain> treeViewCollection)
        {
            using (var fs = new FileStream(FileServer.structPathFaculty, FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                    foreach (var levelOneItem in JsonConvert.DeserializeObject<ObservableCollection<TreeViewMain>>(sr.ReadToEnd()))
                    {
                        var treeViewItemOne = new TreeViewMain(levelOneItem.Title);

                        foreach (var levelTwoItem in levelOneItem.Items)
                        {
                            var treeViewItemTwo = new TreeViewFaculty(levelTwoItem.Title);

                            foreach (var levelThreeItem in levelTwoItem.Items)
                            {
                                var treeViewItemThree = new TreeViewDepartment(levelThreeItem.Title);
                                treeViewItemTwo.Items.Add(treeViewItemThree);
                            }

                            treeViewItemOne.Items.Add(treeViewItemTwo);
                        }

                        treeViewCollection.Add(treeViewItemOne);
                    }
                }
            }
        }
        public void GetTreeViewEducationItem(ObservableCollection<TreeViewLvlOne> treeViewCollection)
        {
            using (var fs = new FileStream(FileServer.structPathEducation, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    foreach (var levelOneItem in JsonConvert.DeserializeObject<ObservableCollection<TreeViewLvlOne>>(sr.ReadToEnd()))
                    {
                        var treeViewItemOne = new TreeViewLvlOne(levelOneItem.Title);

                        foreach (var levelTwoItem in levelOneItem.Items)
                        {
                            var treeViewItemTwo = new TreeViewLvlTwo(levelTwoItem.Title);

                            foreach (var levelThreeItem in levelTwoItem.Items)
                            {
                                var treeViewItemThree = new TreeViewLvlThree(levelThreeItem.Title);

                                foreach (var levelFourItem in levelThreeItem.Items)
                                {
                                    var treeViewItemFour = new TreeViewLvlFour(levelFourItem.Title);
                                    treeViewItemThree.Items.Add(treeViewItemFour);
                                }
                                treeViewItemTwo.Items.Add(treeViewItemThree);
                            }
                            treeViewItemOne.Items.Add(treeViewItemTwo);
                        }
                        treeViewCollection.Add(treeViewItemOne);
                    }
                }
            }
        }


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


        public ObservableCollection<TreeViewLvlOne> TreeViewEducation()
        {
            ObservableCollection<TreeViewLvlOne> collection = new ObservableCollection<TreeViewLvlOne>();

            using (var fs = new FileStream(FileServer.structPathEducation, FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                    collection = JsonConvert.DeserializeObject<ObservableCollection<TreeViewLvlOne>>(sr.ReadToEnd());
                    return collection;
                }
            }
        }
        public ObservableCollection<TreeViewMain> TreeViewFaculty()
        {
            ObservableCollection<TreeViewMain> collection = new ObservableCollection<TreeViewMain>();

            using (var fs = new FileStream(FileServer.structPathFaculty, FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                    collection = JsonConvert.DeserializeObject<ObservableCollection<TreeViewMain>>(sr.ReadToEnd());
                    return collection;
                }
            }
        }


        public void SerializeEnrollee(AddChangeEnrolleeViewModel enrollee)
        {
            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            using (FileStream fs = new FileStream(Path.Combine(FileServer.Enrollees,
                $"{enrollee.epivm.SurName}{enrollee.epivm.Name}{enrollee.epivm.MiddleName}.json"), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    try
                    {
                        sw.Write(JsonConvert.SerializeObject(enrollee,options));
                    }
                    catch(Exception e)
                    {
                        DialogError error = new DialogError();
                        error.Error(e.Message);
                    }
                }
            }
        }


        //Десериализация TreeViewMain
        public ObservableCollection<TreeViewMain> DeserializeTreeViewMain()
        {
            using (var fs = new FileStream(FileServer.structPathFaculty, FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                    return JsonConvert.DeserializeObject<ObservableCollection<TreeViewMain>>(sr.ReadToEnd());
                }
            }
        }
    }
}