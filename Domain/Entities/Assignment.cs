using DomainEnums;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public sealed class Assignment
    {
        [Key]
        public int Id { get; set; }
        public DateTime DueDate { get; set; }
        public int IdCategory { get; set; }
        public Category Category { get; set; }
        public EStatus Status { get; set; }
        public string? Description { get; set; }
        public bool Completed { get; set; }
        public bool Active { get; set; }
    }
}
