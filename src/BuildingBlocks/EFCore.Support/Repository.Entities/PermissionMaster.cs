using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class PermissionMaster
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }
        public string DisplayName { get; set; }        
        public int Category { get; set; }
    }

    public class UserPermissionDetail
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; } //ref. col
        public string PermissionMasterId { get; set; }
        public bool Status { get; set; } //Permission Status true/false
    }
}
