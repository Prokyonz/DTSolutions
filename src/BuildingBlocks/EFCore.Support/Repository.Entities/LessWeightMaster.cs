using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class LessWeightMaster
    {
        [Key]
        public int Id { get; set; }
        public int BranchId { get; set; }
        public string Name { get; set; }
        public float MinWeight { get; set; }
        public float MaxWeight { get; set; }
        public float LessWeight { get; set; }

        [ForeignKey("BranchId")]
        public virtual BranchMaster BranchMaster { get; set; }
    }
}
