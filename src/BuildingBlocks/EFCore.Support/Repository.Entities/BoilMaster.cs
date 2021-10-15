using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class BoilMaster
    {
        public int Sr { get; set; }
        [Key]
        public Guid Id { get; set; }
        public int BoilNo { get; set; }
        public int JangadNo { get; set; }
        public Guid CompanyId { get; set; }
        public Guid BranchId { get; set; }
        public DateTime? EntryDate { get; set; }
        public Guid FinancialId { get; set; }
        public int BoilType { get; set; } //Send, Receive
        public Guid KapanId { get; set; }
        public Guid ShapeId { get; set; }
        public Guid SizeId { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Weight { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal LossWeight { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal RejectionWeight { get; set; }
        public Guid HandOverById { get; set; }
        public Guid HandOverToId { get; set; }        
        public string SlipNo { get; set; }
        public int BoilCategoy { get; set; } // 0 -> Received Carats, 1-> Loss Carets -> Rejection Carates
        public string Remarks { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
