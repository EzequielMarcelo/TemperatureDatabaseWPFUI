using System.IO.Ports;
using TemperatureDataBaseWPF.Models;
using TemperatureDataBaseWPF.Settings;

namespace TemperatureDataBaseWPF.Services
{
    public class SerialDataAcquisition
    {
        private CSVService _csvHelper;

        //Commands for decode
        private const string READ_TEMP = "T";

        private SerialPort _serialPort;

        public EventHandler<double> OnUpdateTemperature;

        public SerialDataAcquisition(CSVService csvHelper)
        {
            _csvHelper = csvHelper;
            _serialPort = new SerialPort();
            _serialPort.DataReceived += SerialPort_DataReceived;
            Connect();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           while(_serialPort.BytesToRead > 0)
            {
                var rawData = _serialPort.ReadLine();
                rawData = rawData.Split("\r").FirstOrDefault();  //Remove \r from data
                Decode(rawData);
            }
        }
        private void Decode(string rawData)
        {
            var sepateData = rawData.Split(":");
            string command = sepateData[0];

            switch(command)
            {
                case READ_TEMP:
                    double tempCelsius = double.Parse(sepateData[1]);
                    OnUpdateTemperature?.Invoke(this, tempCelsius);

                    var data = new List<DataBaseModel>()
                    {
                        new DataBaseModel { Temperature = tempCelsius.ToString("F2"), 
                                            Time = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss tt") }
                    };
                    _csvHelper.SaveData(data);
                    break;
            }            
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
        public void SendCommad(string command, int parameter)
        {
            string message = command + ":" + parameter.ToString();

            if(_serialPort.IsOpen)
                _serialPort.WriteLine(message);
        }
    }
}
