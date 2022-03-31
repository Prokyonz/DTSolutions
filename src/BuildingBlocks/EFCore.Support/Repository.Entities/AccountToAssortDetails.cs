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
        public string PurchaseDetailsId { get; set; }
        public string SlipNo { get; set; }
        public string ShapeId { get; set; }
        public string SizeId { get; set; }
        public string PurityId { get; set; }
        public string BoilProcessId { get; set; }
        public string CharniProcessId { get; set; }
        public string GalaProcessId { get; set; }
        public string NumberProcessId { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Weight { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal AssignWeight { get; set; }

        [ForeignKey("AccountToAssortMasterId")]
        public virtual AccountToAssortMaster AccountToAssortMaster { get; set; }
    }
}
