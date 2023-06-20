namespace APILogs.Application.Dto
{
    public class LogRequestDto
    {
        public string? Application { get; set; }

        public string? Frequency { get; set; }

        public LogDto? Log { get; set; }
    }
}
