using Entities.Transports.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RequisitionHandlers.Contracts.Base
{
    public interface IBaseRequisitionHandler<E, T> where E : class where T : class, ITransport
    {
        public E Add(T toAdd);
        public E GetById(int id);
        public E Update(T toUpdate);
        public bool Remove(int id);

    }
}
