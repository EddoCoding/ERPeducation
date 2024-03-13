using ERPeducation.Common.Interface;
using ERPeducation.Common.Services;
using System;

namespace ERPeducation.Common.Validator
{
    public class ValidationString : IValidation
    {
        IDialogError _dialogError = new DialogError();

        public bool Validation(string valid) => throw new NotImplementedException();

        public bool Validation(string stringValidation1, string stringValidation2) => throw new NotImplementedException();

        public bool Validation(string stringValidation1, string stringValidation2, int stringLength)
        {
            if (String.IsNullOrWhiteSpace(stringValidation1))
            {
                _dialogError.Error("Поля не заполнены");
                return false;
            }
            if(String.IsNullOrWhiteSpace(stringValidation2))
            {
                _dialogError.Error("Поля не заполнены");
                return false;
            }
            if(stringValidation2.Length < 8)
            {
                _dialogError.Error($"Идентификатор должен быть не менее:\n {stringLength} символов");
                return false;
            }
            return true;
        }
    }
}
