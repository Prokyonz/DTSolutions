using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Repository.Entities
{
    public class UserRoleMaster
    {
        public int Sr { get; set; }
        [Key]
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        [ForeignKey("RoleId")]
        public virtual RoleMaster RoleMaster { get; set; }

        [ForeignKey("UserId")]
        public virtual UserMaster UserMaster { get; set; }
    }
}
