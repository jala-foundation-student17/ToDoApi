using Entities.Transports.Contracts;

namespace Entities.Transports
{
    public sealed class CategoryTransport : ITransport
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
