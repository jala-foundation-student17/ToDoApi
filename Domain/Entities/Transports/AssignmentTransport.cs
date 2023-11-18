using DomainEnums;
using Entities.Transports.Contracts;

namespace Entities.Transports
{
    public sealed class AssignmentTransport : ITransport
    {
        public int Id { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int IdCategory { get; set; }
        public EStatus AssignmentStatus { get; set; }
        public string? Description { get; set; }
        public bool Completed { get; set; }
        public bool Active { get; set; }
    }
}
