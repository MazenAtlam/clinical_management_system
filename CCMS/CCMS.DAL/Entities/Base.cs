using System.ComponentModel.DataAnnotations;

namespace CCMS.DAL.Entities
{
    public abstract class Base
    {
        [Required]
        [MaxLength(100)]
        public string CreatedBy { get; private set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;
        public string? ModifiedBy { get; private set; } = null;
        [MaxLength(100)]
        public DateTime? ModifiedOn { get; private set; } = null;
        public bool IsDeleted { get; private set; } = false;
        public DateTime? DeletedOn { get; private set; } = null;

        protected Base() { }
        protected Base(string createdBy) => CreatedBy = createdBy;

        public void Delete(string modifiedBy)
        {
            IsDeleted = true;
            DeletedOn = DateTime.Now;
            SaveModification(modifiedBy);
        }

        public void SaveModification(string modifiedBy)
        {
            ModifiedBy = modifiedBy;
            ModifiedOn = DateTime.Now;
        }
    }
}
