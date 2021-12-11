using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class SalesDetails
    {
        public int Sr { get; }
        [Key]
        public string Id { get; set; }
        public string SalesId { get; set; }
        public string KapanId { get; set; }
        public string ShapeId { get; set; }
        public string SizeId { get; set; }
        public string PurityId { get; set; }
        public string CharniSizeId { get; set; }
        public string GalaSizeId { get; set; }
        public string NumberSizeId { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Weight { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal TIPWeight { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal CVDWeight { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal RejectedPercentage { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal RejectedWeight { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal LessWeight { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal LessDiscountPercentage { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal LessWeightDiscount { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal NetWeight { get; set; }
        public double SaleRate { get; set; }
        public double CVDCharge { get; set; }
        public double CVDAmount { get; set; }
        public double? RoundUpAmount { get; set; }
        public double Amount { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public double CurrencyRate { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public double CurrencyAmount { get; set; }
        public bool IsTransfer { get; set; }
        public string TransferParentId { get; set; }
        public int Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        [ForeignKey("SalesId")]
        public virtual SalesMaster SalesMaster { get; set; }

    }
}
