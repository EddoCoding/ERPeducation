using ERPeducation.Common.Interface;

namespace ERPeducation.ViewModels.Modules.DeanRoom.Old.Services
{
    public interface IEducationalService<T>
    {
        IJSONService jsonService { get; set; }
    }
}