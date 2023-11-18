using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("categories")]

    public sealed class Category
    {
        public Category(string description)
        {
            ChangeDescription(description);
        }

        [Key]
        public int Id { get; private set; }
        public string Description { get; private set; }

        public bool ChangeDescription(string newDescription)
        {
            Description = newDescription;
            return true;
        }
    }
}
