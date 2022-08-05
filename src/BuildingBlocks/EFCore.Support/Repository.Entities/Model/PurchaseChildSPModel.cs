using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class PurchaseChildSPModel
    {
        public string Id { get; set; }
        public string PurchaseId { get; set; }
        public string KapanId { get; set; } //Need remove from the deals.
        public string ShapeId { get; set; }
        public string SizeId { get; set; }
        public string PurityId { get; set; }

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
        public double BuyingRate { get; set; }
        public double CVDCharge { get; set; }
        public double CVDAmount { get; set; }
        public double Amount { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public double CurrencyRate { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public double CurrencyAmount { get; set; }
        public bool IsTransfer { get; set; }
        public string TransferParentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string PurityName { get; set; }
        public string SizeName { get; set; }
        public string ShapeName { get; set; }
    }
}
