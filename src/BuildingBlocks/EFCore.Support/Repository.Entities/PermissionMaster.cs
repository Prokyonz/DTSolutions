using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class PermissionMaster
    {
        public int Sr { get; set; }
        [Key]
        public Guid Id { get; set; }
        public Guid ModuleId { get; set; }
        public string Name { get; set; }        
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        [ForeignKey("ModuleId")]
        public virtual ModuleMaster ModuleMaster { get; set; }
    }
}
