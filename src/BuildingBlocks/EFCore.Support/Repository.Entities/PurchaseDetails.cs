using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class PurchaseDetails
    {
        public int Sr { get; set; }
        [Key]
        public Guid Id { get; set; }
        public Guid PurchaseId { get; set; }
        public Guid KapanId { get; set; }
        public Guid ShapeId { get; set; }
        public Guid SizeId { get; set; }
        public Guid PurityId { get; set; }

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
        public double RoundUpAmount { get; set; }
        public double Total { get; set; }
        public bool IsTransfer { get; set; }
        public Guid TransferParentId { get; set; }        
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        [ForeignKey("PurchaseId")]
        public virtual PurchaseMaster PurchaseMaster { get; set; }

    }
}
