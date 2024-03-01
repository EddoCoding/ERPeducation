using ERPeducation.Common.BD;
using ERPeducation.Common.Interface;
using ERPeducation.ViewModels.Modules.Administration.Struct;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace ERPeducation.Common.Services
{
    public class JSONService : IJSONService
    {
        public void GetTreeViewLvlItem(ObservableCollection<TreeViewLvlOne> treeViewCollection)
        {
            if (!File.Exists(StaticBD.structPathEducation))
            {
                File.WriteAllText(StaticBD.structPathEducation, JsonSerializer.Serialize(new ObservableCollection<TreeViewLvlOne>()
                {
                    new TreeViewLvlOne("Уровни подготовки")
                }));
            }
            if (File.Exists(StaticBD.structPathEducation))
            {
                foreach (var levelOneItem in JsonSerializer.Deserialize<ObservableCollection<TreeViewLvlOne>>(File.ReadAllText(StaticBD.structPathEducation)))
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
}