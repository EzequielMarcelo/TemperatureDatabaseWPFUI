using System.IO.Ports;

namespace TemperatureDataBaseWPF.Services
{
    public class SerialDataAcquisition
    {
        public SerialDataAcquisition()
        {
            
        }
        public string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }
    }
}
