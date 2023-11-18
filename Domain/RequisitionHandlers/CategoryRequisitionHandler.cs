using DomainEnums;
using Entities;
using Entities.Transports;
using InfrastructureContracts.Repositories;
using RequisitionHandlers.Contracts;
using RequisitionHandlers.Contracts.Base;
using System.Linq.Expressions;

namespace RequisitionHandlers;

public sealed class CategoryRequisitionHandler : ICategoryRequisitionHandler
{
    private readonly ICategoryRepository _repo;
    public CategoryRequisitionHandler(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public Category Add(CategoryTransport transport)
        => _repo.Add(new Category(transport.Description));

    public Category GetById(int id)
        => _repo.GetById(id);

    public bool Remove(int id)
        => _repo.Remove(id);

    public Category Update(CategoryTransport transport)
    {
        var toUpdate = _repo.GetById(transport.Id);
        if (toUpdate is null) 
        {
            throw new ArgumentException("Entity does not exists");
        }
        else
        {
            toUpdate.ChangeDescription(transport.Description);
            _repo.Update(toUpdate);
        }

        return toUpdate;
    }
}
