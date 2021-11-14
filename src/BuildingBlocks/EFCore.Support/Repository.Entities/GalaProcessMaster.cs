using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class GalaProcessMaster
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }
        public int GalaNo { get; set; }
        public int JangadNo { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string EntryDate { get; set; }
        public string EntryTime { get; set; }
        public string FinancialYearId { get; set; }
        public int GalaProcessType { get; set; } //Send, Receive
        public string KapanId { get; set; }
        public string ShapeId { get; set; }
        public string SizeId { get; set; }
        public string PurityId { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Weight { get; set; }
        public string GalaNumberId { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal GalaWeight { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal LossWeight { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal RejectionWeight { get; set; }
        public string HandOverById { get; set; }
        public string HandOverToId { get; set; }
        public string SlipNo { get; set; }
        public int GalaCategoy { get; set; } // 0 -> Received Carats, 1-> Loss Carets -> Rejection Carates
        public string Remarks { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}      