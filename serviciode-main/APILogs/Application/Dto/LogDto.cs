namespace APILogs.Application.Dto
{
    public class LogDto
    {
        public string? PartitionKey { get; set; }

        public string? NameMethod { get; set; }

        public DateTime TimeStamp { get; set; }

        public int ElapsedTime { get; set; }

        public string? Session { get; set; }

        public int Code { get; set; }

        public string? Comment { get; set; }

        public string? DocumentId { get; set; }

        public string? Version { get; set; }

        public string? Api { get; set; }

        public string? IpAddress { get; set; }

        public string? Proccess { get; set; }

        public string? Identification { get; set; }

        public string? Level { get; set; }
    }
}
