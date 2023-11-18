using Entities;
using InfrastructureContracts.DataAccess;
using InfrastructureContracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories;

public sealed class CategoryRepository : ICategoryRepository
{
    private readonly DbSet<Category> _dbSet;
    private readonly IMySqlContext _context;

    public CategoryRepository(IMySqlContext context)
    {
        _dbSet = context.Set<Category>();
        _context = context;
    }

    public Category Add(Category toAdd)
    {
        _dbSet.Add(toAdd);
        if (SaveChanges())
        {
            return toAdd;
        }
        throw new ArgumentException("Unable to add entity");
    }

    public Category GetById(int id)
        => _dbSet.FirstOrDefault(x=>x.Id == id);

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

    public Category Update(Category toUpdate)
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
