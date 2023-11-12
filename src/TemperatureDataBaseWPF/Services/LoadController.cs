namespace TemperatureDataBaseWPF.Services
{
    public class LoadController
    {
        private CancellationTokenSource _loadControlCancel;

        public LoadController()
        {
            _loadControlCancel = new CancellationTokenSource();
        }
        private async Task LoadControlRoutine()
        {
            while(!_loadControlCancel.IsCancellationRequested)
            {
                WorkRoutine();
                await Task.Delay(20000);
                PauseRoutine();
                await Task.Delay(10000);
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
        public void SetParameters()
        {
            Stop();
            Start();
        }        
    }
}
