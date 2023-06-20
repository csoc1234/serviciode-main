namespace Login.Infrastructure.Logger.Models
{
    public class StepProcess
    {
        public double TimeElapse { get; set; }
        public DateTime HoraProcess { get; set; }
        public string NameProcess { get; set; }
        public string Comment { get; set; }
        public string LevelInfo { get; set; }
        Enum levelMsn;
    }
}
