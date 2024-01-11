using TemperatureDataBaseWPF.Models;

namespace TemperatureDataBaseWPF.Services
{
    public class LoadController
    {
        private SerialDataAcquisition _serialHandler;
        private ParametersModel _parameters;

        private CancellationTokenSource _loadControlCancel;

        private bool _randomMode = false;

        private const string LOAD_COMMAND = "L";

        public LoadController(SerialDataAcquisition serialHandler)
        {
            _serialHandler = serialHandler;
            _loadControlCancel = new CancellationTokenSource();
            _parameters = new ParametersModel();
        }
        private async Task LoadControlRoutine()
        {
            while (!_loadControlCancel.IsCancellationRequested)
            {
                try
                {
                    var currentParameters = _parameters;

                    if(_randomMode)
                        currentParameters = RandomParametersGenerator(_parameters);
                 
                    WorkRoutine(currentParameters.DutyCycle);
                    await Task.Delay(currentParameters.WorkDuration * 1000, _loadControlCancel.Token);  //Convert to milliseconds
                    PauseRoutine();
                    await Task.Delay(currentParameters.PauseDuration * 1000, _loadControlCancel.Token); //Convert to milliseconds
                }
                catch
                {

                }
            }
        }
        private void WorkRoutine(int dutyCicle)
        {
            _serialHandler.SendCommad(LOAD_COMMAND, dutyCicle);
        }
        private void PauseRoutine()
        {
            _serialHandler.SendCommad(LOAD_COMMAND, 0);   //Off
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
        public void SetParameters(ParametersModel parameters, bool randomMode)
        {
            Stop();
            _parameters = new ParametersModel(parameters);
            _randomMode = randomMode;
            Start();
        }
        private ParametersModel RandomParametersGenerator(ParametersModel parametersMax)
        {
            var random = new Random();

            var newParameters = new ParametersModel
            {
                DutyCycle = random.Next(10, parametersMax.DutyCycle),
                PauseDuration = random.Next(1, parametersMax.PauseDuration),
                WorkDuration = random.Next(1, parametersMax.WorkDuration)
            };

            return newParameters;
        }
    }
}
