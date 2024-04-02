using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class TransferDetails
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }
        public string TransferMasterId { get; set; }
        public string FromCategory { get; set; }
        public string BranchId { get; set; }
        public string ShapeId { get; set; }
        public decimal Carat { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public double Rate { get; set; }
        public double Amount { get; set; }
        public string ToCategory { get; set; }
        public string ToSizeId { get; set; }
        public string ToBranchId { get; set; }
        public string ToNumberIdORKapanId { get; set; }
        public decimal ToCarat { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public double ToRate { get; set; }
        public double ToAmount { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}

