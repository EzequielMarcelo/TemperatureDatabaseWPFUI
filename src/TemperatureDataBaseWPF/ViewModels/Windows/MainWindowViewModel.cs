﻿// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Collections.ObjectModel;
using TemperatureDataBaseWPF.Utility;
using TemperatureDataBaseWPF.Views.Pages;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;

namespace TemperatureDataBaseWPF.ViewModels.Windows
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _applicationTitle = string.Empty;

        [ObservableProperty]
        private ObservableCollection<object> _menuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Home",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                TargetPageType = typeof(HomePageView)
            },
            new NavigationViewItem()
            {
                Content = "Parameters",
                Icon = new SymbolIcon { Symbol = SymbolRegular.EditSettings24 },
                TargetPageType = typeof(Views.Pages.SetParametersPageView)
            }
        };

        [ObservableProperty]
        private ObservableCollection<object> _footerMenuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Settings",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                TargetPageType = typeof(Views.Pages.SettingsPage)
            }
        };

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new()
        {
            new MenuItem { Header = "Home", Tag = "tray_home" }
        };

        public MainWindowViewModel()
        {
            _applicationTitle = AssemblyUtility.GetAssemblyTitle();
        }        
    }
}
