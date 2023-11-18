using DomainEnums;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public sealed class Assignment
    {
        public Assignment(DateTime dueDate, int idCategory, EStatus status, string? description)
        {
            ChangeDueDate(dueDate);
            ChangeCategory(idCategory);
            ChangeStatus(status);
            ChangeDescription(description);
            Active = true;
        }

        [Key]
        public int Id { get; private set; }
        public DateTime DueDate { get; private set; }
        public int IdCategory { get; private set; }
        public Category Category { get; private set; }
        public EStatus Status { get; private set; }
        public string? Description { get; private set; }
        public bool Completed { get; private set; }
        public bool Active { get; private set; }

        public bool ChangeDueDate(DateTime newDueDate)
        {
            DueDate = newDueDate;
            return true;
        }

        public bool ChangeCategory(int idCategory)
        {
            IdCategory = idCategory;
            return true;
        }

        public bool ChangeStatus(EStatus newStatus)
        {
            Status = newStatus;
            return true;
        }

        public bool ChangeDescription(string newDescription)
        {
            Description = newDescription;
            return true;
        }

        public bool IsCompleted()
        {
            Completed = true;
            return true;
        }

        public bool Deactivate()
        {
            Active = false;
            return true;
        }
    }
}
