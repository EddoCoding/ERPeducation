using ReactiveUI;
using System;

namespace ERPeducation.ViewModels.Modules.Administration.Struct.Education
{
    public class TreeViewLvlFour : TreeViewBaseClass
    {
        public event Action<TreeViewLvlFour>? OnDelete;

        public TreeViewLvlFour(string title)
        {
            Title = title;

            Del = ReactiveCommand.Create(() =>
            {
                OnDelete?.Invoke(this);
            });
        }
    }
}
