namespace TemperatureDataBaseWPF.Models
{
    public class ParametersModel
    {
        public int DutyCycle { get; set; }
        public int WorkDuration { get; set; }
        public int PauseDuration { get; set; }

        public ParametersModel()
        {
            DutyCycle = 255;      //0 to 255 (1 byte)
            WorkDuration = 10;    //In seconds
            PauseDuration = 5;    //In seconds
        }
        public ParametersModel(ParametersModel parameters) => DeepCopy(parameters);

        public void DeepCopy(ParametersModel copy)
        {
            DutyCycle = copy.DutyCycle;
            WorkDuration = copy.WorkDuration;
            PauseDuration = copy.PauseDuration;
        }
    }
}
