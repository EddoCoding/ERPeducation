using ERPeducation.Common.Interface.DialogPersonal;
using ERPeducation.Common.Services;
using ERPeducation.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace ERPeducation
{

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IDialogService dialogService = new DialogService();
            dialogService.OpenMainWindow();
        }
    }
}