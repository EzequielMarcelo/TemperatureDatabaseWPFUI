namespace TemperatureDataBaseWPF.Models
{
    public class DataBaseModel
    {
        public float Temperature {  get; set; }
        public DateTime Time { get; set; }
        public DataBaseModel()
        {
            Temperature = 0;
            Time = DateTime.Now;
        }
    }
}
