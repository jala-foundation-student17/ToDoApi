using Entities.Transports;
using Entities;
using RequisitionHandlers.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEnums;

namespace RequisitionHandlers.Contracts
{
    public interface IAssignmentRequisitionHandler : IBaseRequisitionHandler<Assignment, AssignmentTransport>
    {
        public IList<Assignment> GetByStatus(EStatus status);
        public IList<Assignment> GetCompleted();
        public IList<Assignment> GetNotCompleted();
        public IList<Assignment> GetDueDateHigherThan(DateTime dateToGet);
        public IList<Assignment> GetDueDateLessThan(DateTime dateToGet);
    }
}
