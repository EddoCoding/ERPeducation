using ReactiveUI;
using System;

namespace ERPeducation.ViewModels.Modules.Administration.Struct.Faculty
{
    public class TreeViewFacultyItemThree : TreeViewFacultyBaseClass
    {
        public event Action<TreeViewFacultyItemThree>? OnDelete;

        public TreeViewFacultyItemThree(string title)
        {
            Title = title;

            Del = ReactiveCommand.Create(() =>
            {
                OnDelete?.Invoke(this);
            });
        }
    }
}
