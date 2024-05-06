using ERPeducation.Models.AdmissionCampaign.Directions.TestEGG;
using System.Windows;
using System.Windows.Controls;

namespace ERPeducation.Common.Selectors
{
    public class SelectorTestEGE : DataTemplateSelector
    {
        public DataTemplate TemplateTest{ get; set; }
        public DataTemplate TemplateEGE { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Test) return TemplateTest;
            else if (item is EGE) return TemplateEGE;

            return null;
        }
    }
}