namespace TemperatureDataBaseWPF.Services
{
    public class Service : IService
    {
        private SerialDataAcquisition _serialHandler;
        private LoadController _loadController;
        private CSVService _csvService;

        public Service()
        {
            _serialHandler = new SerialDataAcquisition();
            _loadController = new LoadController(_serialHandler);
            _csvService = new CSVService();
        }

        #region Interface
        public SerialDataAcquisition SerialHandler => _serialHandler;
        public LoadController LoadController => _loadController;
        #endregion
    }
}
