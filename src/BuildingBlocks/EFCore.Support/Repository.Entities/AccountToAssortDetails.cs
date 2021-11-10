using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class AccountToAssortDetails
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }
        public string AccountToAssortMasterId { get; set; }
        public string SlipNo { get; set; }
        public string ShapeId { get; set; }
        public string SizeId { get; set; }
        public string PurityId { get; set; }
        
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Weight { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal AssignWeight { get; set; }

        [ForeignKey("AccountToAssortMasterId")]
        public virtual AccountToAssortMaster AccountToAssortMaster { get; set; }
    }
}
