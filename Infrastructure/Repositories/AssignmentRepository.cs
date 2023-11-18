using Entities;
using InfrastructureContracts.DataAccess;
using InfrastructureContracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories;

public sealed class AssignmentRepository : IAssignmentRepository
{
    private readonly DbSet<Assignment> _dbSet;
    private readonly IMySqlContext _context;

    public AssignmentRepository(IMySqlContext context)
    {
        _dbSet = context.Set<Assignment>();
        _context = context;
    }

    public Assignment Add(Assignment toAdd)
    {
        _dbSet.Add(toAdd);
        if (SaveChanges())
        {
            return toAdd;
        }
        throw new ArgumentException("Unable to add entity");
    }

    public IList<Assignment> GetByFilter(Expression<Func<Assignment, bool>> filter)
        => _dbSet.Where(filter).ToList();

    public bool Remove(int id)
    {
        var toRemove = _dbSet.FirstOrDefault(x => x.Id == id);
        if(toRemove is null) 
        {
            throw new ArgumentException("Entity does not exist.");

        }
        _dbSet.Remove(toRemove);
        if (SaveChanges())
        {
            return true;
        }
        return false;
    }

    public Assignment Update(Assignment toUpdate)
    {
        _dbSet.Update(toUpdate);
        if (SaveChanges())
        {
            return toUpdate;
        }
        throw new ArgumentException("Unable to update entity");
    }

    private bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }

}
