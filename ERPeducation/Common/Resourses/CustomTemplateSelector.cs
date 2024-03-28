using ERPeducation.ViewModels.Modules.AdmissionCampaign;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.EducationDocuments;
using ERPeducation.ViewModels.Modules.AdmissionCampaign.PersonalDocuments;
using System.Windows;
using System.Windows.Controls;

namespace ERPeducation.Common.Resourses
{
    public class CustomTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TemplateDocument { get; set; }
        public DataTemplate TemplateEducation { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is PersonalDocumentBase) return TemplateDocument;
            if (item is EducationDocumentBase) return TemplateEducation;

            return base.SelectTemplate(item, container);
        }
    }
}
