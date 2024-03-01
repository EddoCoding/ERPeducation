﻿using ERPeducation.Common.BD;
using ERPeducation.Common.Interface;
using ERPeducation.ViewModels.Modules.Administration.Struct.Education;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace ERPeducation.Common.Services
{
    public class JSONService : IJSONService
    {
        public void GetTreeViewEducationItem(ObservableCollection<TreeViewLvlOne> treeViewCollection)
        {
            string path = StaticBD.structPathEducation;

            if (!File.Exists(path))
            {
                File.WriteAllText(path, JsonSerializer.Serialize(new ObservableCollection<TreeViewLvlOne>()
                {
                    new TreeViewLvlOne("Уровни подготовки")
                }));
            }
            if (File.Exists(path))
            {
                foreach (var levelOneItem in JsonSerializer.Deserialize<ObservableCollection<TreeViewLvlOne>>(File.ReadAllText(path)))
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

        public void GetTreeViewFacultyItem(ObservableCollection<TreeViewFacultyItemOne> treeViewCollection)
        {
            string path = StaticBD.structPathFaculty;

            if (!File.Exists(path))
            {
                File.WriteAllText(path, JsonSerializer.Serialize(new ObservableCollection<TreeViewFacultyItemOne>()
                {
                    new TreeViewFacultyItemOne("Факультеты")
                }));
            }
            if (File.Exists(path))
            {
                foreach (var levelOneItem in JsonSerializer.Deserialize<ObservableCollection<TreeViewFacultyItemOne>>(File.ReadAllText(path)))
                {
                    var treeViewItemOne = new TreeViewFacultyItemOne(levelOneItem.Title);

                    foreach (var levelTwoItem in levelOneItem.Items)
                    {
                        var treeViewItemTwo = new TreeViewFacultyItemTwo(levelTwoItem.Title);

                        foreach (var levelThreeItem in levelTwoItem.Items)
                        {
                            var treeViewItemThree = new TreeViewFacultyItemThree(levelThreeItem.Title);
                            treeViewItemTwo.Items.Add(treeViewItemThree);
                        }

                        treeViewItemOne.Items.Add(treeViewItemTwo);
                    }

                    treeViewCollection.Add(treeViewItemOne);
                }
            }
        }
    }
}