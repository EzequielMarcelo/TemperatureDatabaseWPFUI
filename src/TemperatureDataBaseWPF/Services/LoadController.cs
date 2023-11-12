using TemperatureDataBaseWPF.Models;

namespace TemperatureDataBaseWPF.Services
{
    public class LoadController
    {
        private ParametersModel _parameters;

        private CancellationTokenSource _loadControlCancel;

        public LoadController()
        {
            _loadControlCancel = new CancellationTokenSource();
            _parameters = new ParametersModel();
        }
        private async Task LoadControlRoutine()
        {
            while(!_loadControlCancel.IsCancellationRequested)
            {
                WorkRoutine();
                await Task.Delay(_parameters.WorkDuration * 1000);  //Convert to milliseconds
                PauseRoutine();
                await Task.Delay(_parameters.PauseDuration * 1000); //Convert to milliseconds
            }
        }
        private void WorkRoutine()
        {

        }
        private void PauseRoutine()
        {

        }
        private void Start()
        {
            if (!_loadControlCancel.IsCancellationRequested)
                return;
            _loadControlCancel = new CancellationTokenSource();
            Task.Run(LoadControlRoutine, _loadControlCancel.Token);
        }
        private void Stop()
        {
            _loadControlCancel?.Cancel();
        }
        public void SetParameters(ParametersModel parameters)
        {
            _parameters = new ParametersModel(parameters);   
            Stop();
            Start();
        }        
    }
}
