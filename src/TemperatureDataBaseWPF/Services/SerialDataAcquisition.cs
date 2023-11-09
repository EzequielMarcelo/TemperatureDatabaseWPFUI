using System.IO.Ports;
using TemperatureDataBaseWPF.Settings;

namespace TemperatureDataBaseWPF.Services
{
    public class SerialDataAcquisition
    {
        private SerialPort _serialPort;

        public SerialDataAcquisition()
        {
            _serialPort = new SerialPort();
            Connect();
        }
        private void Connect()
        {
            _serialPort.PortName = SerialPortSettings.Default.PortName;
            _serialPort.BaudRate = SerialPortSettings.Default.BaudRate;
            
            try
            {
                _serialPort.Close();
                _serialPort.Open();
                _serialPort.DiscardInBuffer();
            }
            catch 
            {
                
            }
            
        }
        public string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }
    }
}
