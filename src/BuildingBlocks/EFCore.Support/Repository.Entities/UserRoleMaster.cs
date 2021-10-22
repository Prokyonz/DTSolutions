using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Repository.Entities
{
    public class UserRoleMaster
    {
        public int Sr { get; }
        [Key]
        public string Id { get; set; }
        public string RoleId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        [ForeignKey("RoleId")]
        public virtual RoleMaster RoleMaster { get; set; }

        [ForeignKey("UserId")]
        public virtual UserMaster UserMaster { get; set; }        
    }
}
