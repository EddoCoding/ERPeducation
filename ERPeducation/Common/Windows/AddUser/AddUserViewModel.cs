﻿using ERPeducation.Common.BD;
using ERPeducation.Common.Interface;
using ERPeducation.Common.Validator;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace ERPeducation.Common.Windows.AddUser
{
    public class AddUserViewModel : ReactiveObject
    {
        ObservableCollection<UserViewModel> users;

        public string TextAddlabbel { get; set; } = "Данные пользователя";
        public string TextButonAddChange { get; set; } = "Добавить";
        [Reactive] public string FullName { get; set; }
        [Reactive] public string Identifier { get; set; }

        #region Свойства доступа
        [Reactive] public bool RectorAccess { get; set; }
        [Reactive] public string TextRectorAccess { get; set; } = "Без доступа";

        [Reactive] public bool DeanRoomAccess { get; set; }
        [Reactive] public string TextDeanRoomAccess { get; set; } = "Без доступа";

        [Reactive] public bool TrainingDivisionAccess { get; set; }
        [Reactive] public string TextTrainingDivisionAccess { get; set; } = "Без доступа";

        [Reactive] public bool TeacherAccess { get; set; }
        [Reactive] public string TextTeacherAccess { get; set; } = "Без доступа";

        [Reactive] public bool AdmissionCampaignAccess { get; set; }
        [Reactive] public string TextAdmissionCampaignAccess { get; set; } = "Без доступа";

        [Reactive] public bool AdministrationAccess { get; set; }
        [Reactive] public string TextAdministrationAccess { get; set; } = "Без доступа";
        #endregion
        #region Общие команды
        public ReactiveCommand<Unit, Unit> GenerationIdentifierCommand { get; set; }
        public ReactiveCommand<Unit, Unit> AddChangeUserCommand { get; set; }
        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; set; }
        #endregion
        #region Команды доступа
        public ReactiveCommand<Unit, Unit> RectorAccessCommand { get; set; }
        public ReactiveCommand<Unit, Unit> DeanRoomAccessCommand { get; set; }
        public ReactiveCommand<Unit, Unit> TrainingDivisionAccessCommand { get; set; }
        public ReactiveCommand<Unit, Unit> TeacherAccessCommand { get; set; }
        public ReactiveCommand<Unit, Unit> AdmissionCampaignCommand { get; set; }
        public ReactiveCommand<Unit, Unit> AdministrationCommand { get; set; }
        #endregion

        IValidation _validation;
        IGetModel _getModel;
        public AddUserViewModel(IValidation validation, IGetModel getModel, ObservableCollection<UserViewModel> users, Action closeWindow) 
        {
            _validation = validation;
            _getModel = getModel;
            this.users = users;
            CloseWindowCommand = ReactiveCommand.Create(closeWindow);

            Identifier = Generation(8);

            InitializingCommandsAddUser();
        }

        public AddUserViewModel(IValidation validation, IJSONService jsonService, ObservableCollection<UserViewModel> users, UserViewModel userModel, Action closeWindow)
        {
            _validation = validation;
            this.users = users;
            CloseWindowCommand = ReactiveCommand.Create(closeWindow);

            GenerationIdentifierCommand = ReactiveCommand.Create(() =>
            {
                Identifier = Generation(8);
            });

            AddChangeUserCommand = ReactiveCommand.Create(() =>
            {
                if (!_validation.Validation(FullName, Identifier, 8)) return;

                UserViewModel user = jsonService.GetFileJson(Path.Combine(FileServer.Users, $"{userModel.Identifier}.json"));

                user.FullName = FullName;
                user.Identifier = Identifier;

                user.RectorAccess = RectorAccess;
                user.DeanRoomAccess = DeanRoomAccess;
                user.TrainingDivisionAccess = TrainingDivisionAccess;
                user.TeacherAccess = TeacherAccess;
                user.AdmissionCampaignAccess = AdmissionCampaignAccess;
                user.AdministrationAccess = AdministrationAccess;

                jsonService.CreateFileJson(FileServer.Users, $"{user.Identifier}.json", FullName, Identifier,
                    RectorAccess, DeanRoomAccess, TrainingDivisionAccess, TeacherAccess, 
                    AdmissionCampaignAccess, AdministrationAccess);

                users.Add(user);
                users.Remove(userModel);
                File.Delete(Path.Combine(FileServer.Users, $"{userModel.Identifier}.json"));

                CloseWindowCommand.Execute().Subscribe();
            });
        }

        void InitializingCommandsAddUser()
        {
            GenerationIdentifierCommand = ReactiveCommand.Create(() =>
            {
                Identifier = Generation(8);
            });

            AddChangeUserCommand = ReactiveCommand.Create(() =>
            {
                if (!_validation.Validation(FullName, Identifier, 8)) return;
                users.Add(_getModel.GetUserModel(FullName, Identifier, RectorAccess, DeanRoomAccess,
                        TrainingDivisionAccess, TeacherAccess, AdmissionCampaignAccess, AdministrationAccess));
                CloseWindowCommand.Execute().Subscribe();
            });

            RectorAccessCommand = ReactiveCommand.Create(() =>
            {
                if (RectorAccess)
                {
                    RectorAccess = true;
                    TextRectorAccess = "Доступ";
                }
                else
                {
                    RectorAccess = false;
                    TextRectorAccess = "Без доступа";
                }
            });
            DeanRoomAccessCommand = ReactiveCommand.Create(() =>
            {
                if (DeanRoomAccess)
                {
                    DeanRoomAccess = true;
                    TextDeanRoomAccess = "Доступ";
                }
                else
                {
                    DeanRoomAccess = false;
                    TextDeanRoomAccess = "Без доступа";
                }
            });
            TrainingDivisionAccessCommand = ReactiveCommand.Create(() =>
            {
                if (TrainingDivisionAccess)
                {
                    TrainingDivisionAccess = true;
                    TextTrainingDivisionAccess = "Доступ";
                }
                else
                {
                    TrainingDivisionAccess = false;
                    TextTrainingDivisionAccess = "Без доступа";
                }
            });
            TeacherAccessCommand = ReactiveCommand.Create(() =>
            {
                if (TeacherAccess)
                {
                    TeacherAccess = true;
                    TextTeacherAccess = "Доступ";
                }
                else
                {
                    TeacherAccess = false;
                    TextTeacherAccess = "Без доступа";
                }
            });
            AdmissionCampaignCommand = ReactiveCommand.Create(() =>
            {
                if (AdmissionCampaignAccess)
                {
                    AdmissionCampaignAccess = true;
                    TextAdmissionCampaignAccess = "Доступ";
                }
                else
                {
                    AdmissionCampaignAccess = false;
                    TextAdmissionCampaignAccess = "Без доступа";
                }
            });
            AdministrationCommand = ReactiveCommand.Create(() =>
            {
                if (AdministrationAccess)
                {
                    AdministrationAccess = true;
                    TextAdministrationAccess = "Доступ";
                }
                else
                {
                    AdministrationAccess = false;
                    TextAdministrationAccess = "Без доступа";
                }
            });
        }

        string Generation(int count)
        {
            string chatacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            StringBuilder sb = new StringBuilder(8);

            for (int i = 0; i < 8; i++)
            {
                int index = random.Next(chatacters.Length);
                sb.Append(chatacters[index]);
            }

            return sb.ToString();
        }
    }
}