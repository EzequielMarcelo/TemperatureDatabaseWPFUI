namespace TemperatureDataBaseWPF.Services
{
    public class Service : IService
    {
        private SerialDataAcquisition _serialHandler;
        private LoadController _loadController;

        public Service()
        {
            _serialHandler = new SerialDataAcquisition();
            _loadController = new LoadController();
        }

        #region Interface
        public SerialDataAcquisition SerialHandler => _serialHandler;
        public LoadController LoadController => _loadController;
        #endregion
    }
}
