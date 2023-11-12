namespace TemperatureDataBaseWPF.Services
{
    public interface IService
    {
        public SerialDataAcquisition SerialHandler { get; }
        public LoadController LoadController { get; }
    }
}
