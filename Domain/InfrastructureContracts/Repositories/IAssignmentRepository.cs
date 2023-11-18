using DomainEnums;
using Entities;
using InfrastructureContracts.Repositories.Base;

namespace InfrastructureContracts.Repositories
{
    public interface IAssignmentRepository : IBaseRepository<Assignment>
    {
        public IList<Assignment> GetByStatus(EStatus status);
        public IList<Assignment> GetCompleted();
        public IList<Assignment> GetNotCompleted();
    }
}
