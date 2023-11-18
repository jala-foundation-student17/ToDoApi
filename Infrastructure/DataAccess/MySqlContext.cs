using Entities;
using InfrastructureContracts.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public sealed class MySqlContext :DbContext, IMySqlContext
{
    public MySqlContext(DbContextOptionsBuilder builder) : base(builder.Options)
    {
        
    }

    public DbSet<Assignment> Assignments { get; set; }
}
