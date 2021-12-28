using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class PaymentDetails
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }
        public string PaymentId { get; set; }
        public string GroupId { get; set; }
        public string PurchaseId { get; set; }
        public string SlipNo { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        [ForeignKey("PaymentId")]
        public virtual PaymentMaster PaymentMaster { get; set; }

    }
}
