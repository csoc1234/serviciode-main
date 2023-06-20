namespace APITemplate.Application.Dto
{
    public class TemplateSaveRequestDto
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string NameTemplate { get; set; }
        public string Source { get; set; }
    }
}
