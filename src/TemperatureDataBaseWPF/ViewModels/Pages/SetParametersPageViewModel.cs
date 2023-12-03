using System.Linq;
using System.Windows.Input;
using TemperatureDataBaseWPF.Models;
using TemperatureDataBaseWPF.Services;

namespace TemperatureDataBaseWPF.ViewModels.Pages
{
    public partial class SetParametersPageViewModel : ObservableObject
    {
        private LoadController _loadControl;
        private CSVService _csvHelper;

        public SetParametersPageViewModel(IService service)
        {
            _loadControl = service.LoadController;
            _csvHelper = service.CsvHelper;

            DutyCycle = 20;
            CurrentMode = WORK_MODE.MANUAL;
            CurrentDataBaseState = DATA_BASE.STANDBY;
            OnChangeWorkMode();
        }

        public enum WORK_MODE
        {
            AUTOMATIC,
            MANUAL
        }
        public enum DATA_BASE
        {
            STANDBY,
            MONITORING            
        }

        [ObservableProperty]
        private int _dutyCycle;

        [ObservableProperty]
        private int _workDuration;
        
        [ObservableProperty]
        private int _pauseDuration;

        [ObservableProperty]
        private WORK_MODE _currentMode;

        [ObservableProperty]
        private DATA_BASE _currentDataBaseState;

        [RelayCommand]
        private void OnChangeWorkMode()
        {
            switch (CurrentMode)
            {
                case WORK_MODE.MANUAL:
                    int b = 0;
                    break;
                case WORK_MODE.AUTOMATIC:
                    int a = 0;
                    break;
            }
        }
        [RelayCommand]
        private void OnSetParameters()
        {
            var parameters = new ParametersModel()
            {
                DutyCycle = DutyCycle,
                WorkDuration = WorkDuration,
                PauseDuration = PauseDuration,
            };
            _loadControl.SetParameters(parameters);
        }
        [RelayCommand]
        private void OnEnableDataBase()
        {
            switch(CurrentDataBaseState)
            {
                case DATA_BASE.STANDBY:
                    _csvHelper.ControlDataSave(false);
                    break;

                case DATA_BASE.MONITORING:
                    _csvHelper.ControlDataSave(true);
                    break;    
            }
        }
    }
}
