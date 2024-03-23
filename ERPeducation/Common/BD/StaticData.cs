using ERPeducation.ViewModels.Modules.Administration.Struct.Education;
using ERPeducation.ViewModels.Modules.Administration.Struct.Faculty;
using System.Collections.ObjectModel;

namespace ERPeducation.Common.BD
{
    public static class StaticData
    {
        public static ObservableCollection<TreeViewLvlOne> LvlEducations;
        public static ObservableCollection<TreeViewFacultyItemOne> Faculties;

        public static ObservableCollection<string> GetLvlEducation()
        {
            ObservableCollection<string> collection = new ObservableCollection<string>();

            foreach (var Directions in LvlEducations)
            {
                foreach (var Direction in Directions.Items)
                {
                    collection.Add(Direction.Title);
                }
            }

            return collection;
        } //ПОЛУЧАЕМ УРОВНИ ПДГОТОВКИ
        public static ObservableCollection<string> GetDirectionEducation(string nameDirection)
        {
            ObservableCollection<string> collection = new ObservableCollection<string>();

            foreach (var Directions in LvlEducations)
            {
                foreach (var Direction in Directions.Items)
                {
                    if(Direction.Title == nameDirection)
                    {
                        foreach(var direction in Direction.Items)
                        {
                            collection.Add(direction.Title);
                        }
                    }
                }
            }

            return collection;
        } //ПОЛУЧАЕМ НАПРАВЛЕНИЯ ПОДГОТОВКИ
        public static ObservableCollection<string> GetFormEducation(string nameForm)
        {
            ObservableCollection<string> collection = new ObservableCollection<string>();

            foreach (var Directions in LvlEducations)
            {
                foreach (var Direction in Directions.Items)
                {
                    foreach (var Forms in Direction.Items)
                    {
                        if(Forms.Title == nameForm)
                        {
                            foreach (var Form in Forms.Items)
                            {
                                collection.Add(Form.Title);
                            }
                        }
                    }
                }
            }

            return collection;
        } //ПОЛУЧАЕМ ФОРМЫ ПОДГОТОВКИ


        public static ObservableCollection<string> GetFaculty()
        {
            ObservableCollection<string> collection = new ObservableCollection<string>();

            foreach (var items in Faculties)
            {
                foreach (var item in items.Items)
                {
                    collection.Add(item.Title);
                }
            }

            return collection;
        } //ПОЛУЧАЕМ ФАКУЛЬТЕТЫ
        //ДОБАВИТЬ ПОЛУЧЕНИЕ КАФЕДР
    }
}