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
    private readonly IAssignmentRepository _assignmentRepo;
    private readonly ICategoryRepository _categoryRepo;
    public AssignmentRequisitionHandler(IAssignmentRepository assignmentRepo, ICategoryRepository categoryRepo)
    {
        _assignmentRepo = assignmentRepo;
        _categoryRepo= categoryRepo;
    }

    public Assignment Add(AssignmentTransport transport)
    {
        var category = _categoryRepo.GetById(transport.IdCategory);
        if(category is null)
        {
            throw new ArgumentException("Category does not exists. ");
        }
        
        return _assignmentRepo.Add(new Assignment(transport.DueDate, transport.IdCategory, (EStatus)transport.AssignmentStatus, transport.Description));
    }

    public Assignment GetById(int id)
        => _assignmentRepo.GetById(id);

    public IList<Assignment> GetByStatus(EStatus status)
    {
        if (!Enum.IsDefined(typeof(EStatus), status))
        {
            throw new ArgumentException("Status not valid.");
        }

        return _assignmentRepo.GetByStatus(status);
    }

    public IList<Assignment> GetCompleted()
        => _assignmentRepo.GetCompleted();

    public IList<Assignment> GetDueDateHigherThan(DateTime dateToGet)
        => _assignmentRepo.GetDueDateHigherThan(dateToGet);

    public IList<Assignment> GetDueDateLessThan(DateTime dateToGet)
    => _assignmentRepo.GetDueDateLessThan(dateToGet);

    public IList<Assignment> GetNotCompleted()
        => _assignmentRepo.GetNotCompleted();

    public bool Remove(int id)
    {
        var toRemove = _assignmentRepo.GetById(id);
        if(toRemove is not null)
        {
            toRemove.Deactivate();
            _assignmentRepo.Update(toRemove);
            return true;
        }
        return false;
    }

    public Assignment Update(AssignmentTransport transport)
    {
        var toUpdate = _assignmentRepo.GetById(transport.Id);
        if (toUpdate is null) 
        {
            throw new ArgumentException("Entity does not exists");
        }
        else
        {
            toUpdate.SetUpdateDate();
            toUpdate.ChangeCategory(transport.IdCategory);
            toUpdate.ChangeDescription(transport.Description);
            toUpdate.ChangeStatus(transport.AssignmentStatus);
            toUpdate.ChangeDueDate(transport.DueDate);
            if (transport.Completed)
            {
                toUpdate.IsCompleted();
            }
            _assignmentRepo.Update(toUpdate);
        }

        return toUpdate;
    }
}
