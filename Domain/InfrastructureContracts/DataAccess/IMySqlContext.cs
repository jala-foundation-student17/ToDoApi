using Microsoft.EntityFrameworkCore;

namespace InfrastructureContracts.DataAccess
{
    public interface IMySqlContext
    {
        DbSet<E> Set<E>() where E : class;

        int SaveChanges();
    }
}
