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
    public interface ICategoryRequisitionHandler : IBaseRequisitionHandler<Category, CategoryTransport>
    {
    }
}
