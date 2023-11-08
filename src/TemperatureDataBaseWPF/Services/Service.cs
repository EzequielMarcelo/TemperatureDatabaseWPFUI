namespace TemperatureDataBaseWPF.Services
{
    public class Service : IService
    {
        private SerialDataAcquisition _serialHandler;

        public Service()
        {
            _serialHandler = new SerialDataAcquisition();
        }

        #region Interface
        public SerialDataAcquisition SerialHandler => _serialHandler;
        #endregion
    }
}
