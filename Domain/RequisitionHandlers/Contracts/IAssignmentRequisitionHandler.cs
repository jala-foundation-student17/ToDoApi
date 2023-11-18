using Entities.Transports;
using Entities;
using RequisitionHandlers.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequisitionHandlers.Contracts
{
    public interface IAssignmentRequisitionHandler : IBaseRequisitionHandler<Assignment, AssignmentTransport>
    {
    }
}
