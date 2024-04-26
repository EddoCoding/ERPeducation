using ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents;
using System.Windows;
using System.Windows.Controls;

namespace ERPeducation.Common.Selectors
{
    public class SelectorDocuments : DataTemplateSelector
    {
        public DataTemplate TemplatePassport { get; set; }
        public DataTemplate TemplateSnils { get; set; }
        public DataTemplate TemplateINN { get; set; }
        public DataTemplate TemplateForeignPassport { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Passport) return TemplatePassport;
            else if (item is Snils) return TemplateSnils;
            else if (item is INN) return TemplateINN;
            else if (item is ForeignPassport) return TemplateForeignPassport;

            return null;
        }
    }
}
