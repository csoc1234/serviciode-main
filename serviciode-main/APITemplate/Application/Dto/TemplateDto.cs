using APITemplate.Common;

namespace APITemplate.Application.Dto
{
    public class TemplateDto : ResponseBase
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string NameTemplate { get; set; }
        public string Source { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool Active { get; set; }
    }
}
