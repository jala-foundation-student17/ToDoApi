using DomainEnums;
using Entities;
using Entities.Transports;
using InfrastructureContracts.Repositories;
using RequisitionHandlers.Contracts;
using RequisitionHandlers.Contracts.Base;
using System.Linq.Expressions;

namespace RequisitionHandlers;

public sealed class AssignmentRequisitionHandler : IAssignmentRequisitionHandler
{
    private readonly IAssignmentRepository _repo;
    public AssignmentRequisitionHandler(IAssignmentRepository repo)
    {
        _repo = repo;
    }

    public Assignment Add(AssignmentTransport transport)
        => _repo.Add(new Assignment(transport.DueDate, transport.IdCategory, transport.Status, transport.Description));

    public Assignment GetById(int id)
        => _repo.GetById(id);

    public bool Remove(int id)
    {
        var toRemove = _repo.GetById(id);
        if(toRemove is not null)
        {
            toRemove.Deactivate();
            _repo.Update(toRemove);
            return true;
        }
        return false;
    }

    public Assignment Update(AssignmentTransport transport)
    {
        var toUpdate = _repo.GetById(transport.Id);
        if (toUpdate is null) 
        {
            throw new ArgumentException("Entity does not exists");
        }
        else
        {
            toUpdate.ChangeCategory(transport.IdCategory);
            toUpdate.ChangeDescription(transport.Description);
            toUpdate.ChangeStatus(transport.Status);
            toUpdate.ChangeDueDate(transport.DueDate);
            if (transport.Completed)
            {
                toUpdate.IsCompleted();
            }
            _repo.Update(toUpdate);
        }

        return toUpdate;
    }
}
