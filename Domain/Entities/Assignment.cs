using DomainEnums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("assignments")]
    public sealed class Assignment
    {
        public Assignment(DateTime dueDate, int idCategory, EStatus assignmentStatus, string? description)
        {
            Active = true;
            Completed = false;
            SetUpdateDate();
            ChangeDueDate(dueDate);
            ChangeCategory(idCategory);
            ChangeStatus(assignmentStatus);
            ChangeDescription(description);
        }

        [Key]
        public int Id { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public int IdCategory { get; private set; }
        public EStatus AssignmentStatus { get; private set; }
        public string? Description { get; private set; }
        public bool Completed { get; private set; }
        public bool Active { get; private set; }

        public bool ChangeDueDate(DateTime newDueDate)
        {
            if(newDueDate.Date < DateTime.Now.Date && Active)
            {
                throw new ArgumentException("Invalid Due Date.");

            }
            DueDate = newDueDate;
            return true;
        }

        public bool ChangeCategory(int idCategory)
        {
            IdCategory = idCategory;
            return true;
        }

        public void SetUpdateDate()
        {
            UpdateDate = DateTime.Now;
        }
        public bool ChangeStatus(EStatus newStatus)
        {
            if(!Enum.IsDefined(typeof(EStatus), newStatus))
            {
                throw new ArgumentException("Status not valid.");
            }
            if(newStatus == EStatus.Done)
            {
                IsCompleted();
            }
            AssignmentStatus = newStatus;
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
