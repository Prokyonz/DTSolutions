using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class PaymentDetails
    {
        public int Sr { get; set; }
        [Key]
        public Guid Id { get; set; }
        public Guid PaymentId { get; set; }
        public Guid? GroupId { get; set; }
        public Guid PurchaseId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        [ForeignKey("PaymentId")]
        public virtual PaymentMaster PaymentMaster { get; set; }

    }
}
