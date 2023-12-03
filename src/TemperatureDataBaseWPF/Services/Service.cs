namespace TemperatureDataBaseWPF.Services
{
    public class Service : IService
    {
        private SerialDataAcquisition _serialHandler;
        private LoadController _loadController;
        private CSVService _csvService;

        public Service()
        {
            _csvService = new CSVService();
            _serialHandler = new SerialDataAcquisition(_csvService);
            _loadController = new LoadController(_serialHandler);
        }

        #region Interface
        public SerialDataAcquisition SerialHandler => _serialHandler;
        public LoadController LoadController => _loadController;
        #endregion
    }
}
