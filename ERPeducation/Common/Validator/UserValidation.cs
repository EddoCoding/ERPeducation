using ERPeducation.Common.BD;
using ERPeducation.Common.Interface;
using ERPeducation.Common.Services;
using System;
using System.IO;
using System.Windows;

namespace ERPeducation.Common.Validator
{
    public class UserValidation : IValidation
    {
        IDialogError _dialogError = new DialogError();

        public bool Validation(string valid)
        {
            if (!Directory.Exists(FileServer.IS))
            {
                _dialogError.Error("Отсутствует ИС!");
                return false;
            }
            if(String.IsNullOrEmpty(FileServer.PathIS) || String.IsNullOrEmpty(valid))
            {
                _dialogError.Error("Некорректный ввод!");
                return false;
            }
            else if(Directory.Exists(FileServer.IS) && !String.IsNullOrEmpty(FileServer.PathIS) && !String.IsNullOrEmpty(valid))
            {
                if (File.Exists(Path.Combine(FileServer.Users, $"{valid}.json"))) return true;
                else _dialogError.Error("Некорректный ввод!");
            }

            return false;
        }
    }
}
