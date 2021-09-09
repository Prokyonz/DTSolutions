using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class SalesDetails
    {
        public int Sr { get; set; }
        [Key]
        public Guid Id { get; set; }
        public Guid SalesId { get; set; }
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
        public double SaleRate { get; set; }
        public double CVDCharge { get; set; }
        public double CVDAmount { get; set; }
        public double RoundUpAmount { get; set; }
        public double Total { get; set; }
        public string FromCategory { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        [ForeignKey("SalesId")]
        public virtual PurchaseMaster SalesMaster { get; set; }

    }
}
