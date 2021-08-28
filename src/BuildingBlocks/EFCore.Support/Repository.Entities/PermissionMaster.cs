using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class PermissionMaster
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModuleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        [ForeignKey("ModuleId")]
        public virtual ModuleMaster ModuleMaster { get; set; }
    }
}
