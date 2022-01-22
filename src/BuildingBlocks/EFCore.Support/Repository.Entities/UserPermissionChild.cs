using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class UserPermissionChild
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }
        public string PermissionMasterId { get; set; }
        public string UserId { get; set; }
        public bool Status { get; set; } //Permission Status true/false

        [ForeignKey("UserId")]
        public virtual UserMaster UserMaster { get; set; }
    }
}
