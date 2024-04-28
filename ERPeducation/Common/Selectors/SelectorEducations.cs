using ERPeducation.Models.AdmissionCampaign.Educations;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.Documents;
using System.Windows;
using System.Windows.Controls;

namespace ERPeducation.Common.Selectors
{
    public class SelectorEducations : DataTemplateSelector
    {
        public DataTemplate TemplateNine { get; set; }
        public DataTemplate TemplateEleven{ get; set; }
        public DataTemplate TemplateSPO { get; set; }
        public DataTemplate TemplateBak { get; set; }
        public DataTemplate TemplateMag { get; set; }
        public DataTemplate TemplateAsp { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is EducationNine) return TemplateNine;
            else if (item is EducationEleven) return TemplateEleven;
            else if (item is EducationSPO) return TemplateSPO;
            else if (item is EducationBak) return TemplateBak;
            else if (item is EducationMag) return TemplateMag;
            else if (item is EducationAsp) return TemplateAsp;

            return null;
        }
    }
}
