// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Collections.ObjectModel;
using System.Windows.Media;
using TemperatureDataBaseWPF.Services;
using TemperatureDataBaseWPF.Utility;
using Wpf.Ui.Controls;

namespace TemperatureDataBaseWPF.ViewModels.Pages
{
    public partial class SettingsViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        private SerialDataAcquisition _serialHandler;

        [ObservableProperty]
        private string _appVersion = String.Empty;

        [ObservableProperty]
        private string _appAbout = String.Empty;

        [ObservableProperty]
        private Wpf.Ui.Appearance.ThemeType _currentTheme = Wpf.Ui.Appearance.ThemeType.Unknown;

        [ObservableProperty]
        private ObservableCollection<string> _portNames;

        [ObservableProperty]
        private string _selectedPortName;

        [ObservableProperty]
        private ObservableCollection<int> _BaudRates;

        [ObservableProperty]
        private int _selectedBaudRate;

        public SettingsViewModel(IService service)
        {
            _serialHandler = service.SerialHandler;
        }

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        public void OnNavigatedFrom() { }

        private void InitializeViewModel()
        {
            CurrentTheme = Wpf.Ui.Appearance.Theme.GetAppTheme();
            AppVersion = $"{AssemblyUtility.GetAssemblyTitle()} - {AssemblyUtility.GetAssemblyVersion()}";
            AppAbout = $"About {AssemblyUtility.GetAssemblyTitle()}";
            PortNames = new ObservableCollection<string>();
            BaudRates = new ObservableCollection<int>()
            {
                9600,
                115200
            };
            
            SelectedBaudRate = BaudRates.First();

            RefreshPortNames();

            _isInitialized = true;
        }

        [RelayCommand]
        private void OnChangeTheme(string parameter)
        {
            switch (parameter)
            {
                case "theme_light":
                    if (CurrentTheme == Wpf.Ui.Appearance.ThemeType.Light)
                        break;

                    Wpf.Ui.Appearance.Theme.Apply(Wpf.Ui.Appearance.ThemeType.Light);
                    CurrentTheme = Wpf.Ui.Appearance.ThemeType.Light;

                    break;

                default:
                    if (CurrentTheme == Wpf.Ui.Appearance.ThemeType.Dark)
                        break;

                    Wpf.Ui.Appearance.Theme.Apply(Wpf.Ui.Appearance.ThemeType.Dark);
                    CurrentTheme = Wpf.Ui.Appearance.ThemeType.Dark;

                    break;
            }
        }

        [RelayCommand]
        private void RefreshPortNames()
        {
            PortNames.Clear();

            foreach (var ports in _serialHandler.GetPortNames())
            {
                PortNames.Add(ports);
            }

            if(PortNames.Count > 0)
                SelectedPortName = PortNames.First();
        }
    }
}
