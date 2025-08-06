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
        protected Base(string creatingUser) => CreatedBy = creatingUser;

        public void Delete(string modifyingUser)
        {
            IsDeleted = true;
            DeletedOn = DateTime.Now;
            SaveModification(modifyingUser);
        }

        public void SaveModification(string modifyingUser)
        {
            ModifiedBy = modifyingUser;
            ModifiedOn = DateTime.Now;
        }
    }
}
