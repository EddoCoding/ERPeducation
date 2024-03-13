namespace ERPeducation.Common.Validator
{
    public interface IValidation
    {
        bool Validation(string stringValidation);
        bool Validation(string stringValidation1, string stringValidation2);
        bool Validation(string stringValidation1, string stringValidation2, int stringLength);
    }
}