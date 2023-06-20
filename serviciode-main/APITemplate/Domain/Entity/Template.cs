using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITemplate.Domain.Entity
{
    public class Template
    {
        public int Id { get; set; }

        public Int16 ProductId { get; set; }

        public int CustomerId { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string NameTemplate { get; set; }

        public byte[] Source { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public bool Active { get; set; }
    }
}
