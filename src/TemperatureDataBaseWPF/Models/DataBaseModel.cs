namespace TemperatureDataBaseWPF.Models
{
    public class DataBaseModel
    {
        public string Temperature {  get; set; }
        public string DutyCycle { get; set; }
        public string Time { get; set; }
        public DataBaseModel()
        {
            Temperature = string.Empty;
            DutyCycle = string.Empty;
            Time = string.Empty;
        }
    }
}
