namespace ERPeducation.ViewModels.Modules.AdmissionCampaign
{
    public class TabItemEnrollee
    {
        public string TitleTabEnrollee { get; set; }
        public object? ContentTabEnrollee { get; set; }

        public TabItemEnrollee(string titleTabEnrollee, object? contentTabEnrollee = default)
        {
            (TitleTabEnrollee, ContentTabEnrollee) = (titleTabEnrollee, contentTabEnrollee);
        }
    }
}