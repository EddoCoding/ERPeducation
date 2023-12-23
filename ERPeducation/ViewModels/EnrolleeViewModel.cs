﻿using ERPeducation.Common;
using ERPeducation.Interface;
using ERPeducation.Views.ModuleEnrolle;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ERPeducation.ViewModels
{
    public class EnrolleeViewModel
    {
        public BaseDataForModules<TabItemEnrollee> Data { get; set; }

        public EnrolleeViewModel() 
        {
            Data = new BaseDataForModules<TabItemEnrollee>()
            {
                DataForTabs = new string[] { "Личная информация", "Контактная информация", "Образование", "Направление подготовки",
                                         "Поданные документы", "Результаты испытаний", "Заключить договор", "Печать"},
                TabItem = new ObservableCollection<TabItemEnrollee>()
            };

            UserControl[] userControls = new UserControl[] 
            { 
                new EnrollePersonalInformationView()
            };

            for (int i = 0; i < Data.DataForTabs.Length; i++)
            {
                Data.TabItem.Add(new TabItemEnrollee(Data.DataForTabs[i], userControls[0]));
            }
        }
    }
}
