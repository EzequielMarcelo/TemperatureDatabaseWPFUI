using System.IO.Ports;
using TemperatureDataBaseWPF.Settings;

namespace TemperatureDataBaseWPF.Services
{
    public class SerialDataAcquisition
    {
        //Commands for decode
        private const string READ_TEMP = "T";

        private SerialPort _serialPort;

        public EventHandler<double> OnUpdateTemperature;

        public SerialDataAcquisition()
        {
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
                    int ADCValue = int.Parse(sepateData[1]);
                    double tempCelsius = GetTempCelsius(ADCValue);
                    OnUpdateTemperature?.Invoke(this, tempCelsius);
                    break;
            }            
        }
        private double GetTempCelsius(int adcValue)
        {
            double voltage = (adcValue * 5.0) / 1023.0; //Voltage = (ADC * maximum input voltage) / maximum ADC value

            return voltage / 0.010; //The lm35 sensor is linear: 10mV/°C
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
