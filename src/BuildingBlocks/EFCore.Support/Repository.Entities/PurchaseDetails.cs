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
        public float Weight { get; set; }
        public float TIPWeight { get; set; }
        public float CVDWeight { get; set; }
        public float RejectedPercentage { get; set; }
        public float RejectedWeight { get; set; }
        public float LessWeight { get; set; }
        public float LessDiscountPercentage { get; set; }
        public float LessWeightDiscount { get; set; }
        public float NetWeight { get; set; }
        public double BuyingRate { get; set; }
        public double CVDCharge { get; set; }
        public double CVDAmount { get; set; }
        public double RoundUpAmount { get; set; }
        public double Total { get; set; }
        public bool IsTransfer { get; set; }
        public Guid TransferParentId { get; set; }        
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        [ForeignKey("PurchaseId")]
        public virtual PurchaseMaster PurchaseMaster { get; set; }

    }
}
