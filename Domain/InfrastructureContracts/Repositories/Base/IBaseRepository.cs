using System.Linq.Expressions;

namespace InfrastructureContracts.Repositories.Base
{
    public interface IBaseRepository<E> where E : class
    {
        public E Add(E toAdd);
        public E GetById(int id);
        public E Update(E toUpdate);
        public bool Remove(int id);
    }
}
