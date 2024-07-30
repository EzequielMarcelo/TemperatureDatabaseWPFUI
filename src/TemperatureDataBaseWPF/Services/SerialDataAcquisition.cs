using System.IO.Ports;
using TemperatureDataBaseWPF.Models;
using TemperatureDataBaseWPF.Settings;

namespace TemperatureDataBaseWPF.Services
{
    public class SerialDataAcquisition
    {
        private CSVService _csvHelper;

        //Commands for decode
        private const string READ_DATA = "D";

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
                try
                {
                    var rawData = _serialPort.ReadLine();
                    rawData = rawData.Split("\r").FirstOrDefault() ?? rawData;  //Remove \r from data
                    Decode(rawData);
                }
                catch { }
                
            }
        }
        private void Decode(string rawData)
        {
            var buffer = rawData.Split(":");
            string command = buffer[0];

            switch(command)
            {
                case READ_DATA:
                    var sepateData = buffer[1].Split(",");
                    double tempCelsius = double.Parse(sepateData[0] ?? "0");
                    OnUpdateTemperature?.Invoke(this, tempCelsius);

                    var data = new List<DataBaseModel>()
                    {
                        new DataBaseModel { Temperature = tempCelsius.ToString("F2"), 
                                            DutyCycle = sepateData[1] ?? "0",
                                            Time = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss tt") }
                    };
                    _csvHelper.SaveData(data);
                    break;
            }            
        }
        public void Connect()
        {            
            try
            {
                _serialPort.Close();

                _serialPort.PortName = SerialPortSettings.Default.PortName;
                _serialPort.BaudRate = SerialPortSettings.Default.BaudRate;

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
