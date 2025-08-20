using CCMS.DAL.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCMS.DAL.Entities
{
    [Table("ApplicationUser", Schema="ccms")]
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public UserType UType { get; private set; }

        [Required]
        [MaxLength(100)]
        public string CreatedBy { get; private set; }
        public DateTime CreatedOn { get; private set; } = DateTime.Now;
        public string? ModifiedBy { get; private set; } = null;
        [MaxLength(100)]
        public DateTime? ModifiedOn { get; private set; } = null;
        public bool IsDeleted { get; private set; } = false;
        public DateTime? DeletedOn { get; private set; } = null;

        //public ApplicationUser() { }
        public ApplicationUser(string createdBy) => CreatedBy = createdBy;

        public void Delete(string modifiedBy)
        {
            IsDeleted = true;
            DeletedOn = DateTime.Now;
            SaveModification(modifiedBy);
        }

        protected void SaveModification(string modifiedBy)
        {
            ModifiedBy = modifiedBy;
            ModifiedOn = DateTime.Now;
        }
    }
}
