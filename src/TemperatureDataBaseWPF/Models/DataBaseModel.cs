namespace TemperatureDataBaseWPF.Models
{
    public class DataBaseModel
    {
        public string Temperature {  get; set; }
        public string Time { get; set; }
        public DataBaseModel()
        {
            Temperature = string.Empty;
            Time = string.Empty;
        }
    }
}
