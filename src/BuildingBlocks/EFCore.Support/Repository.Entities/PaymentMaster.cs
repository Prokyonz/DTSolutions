using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class PaymentMaster
    {
        public int Sr { get; }
        [Key]
        public string Id { get; set; }
        public string GroupId { get; set; }
        public string FromPartyId { get; set; }
        public decimal Amount { get; set; }
        public int CrDrType { get; set; } // 0 -> Debit, 1 -> Credit
        public string ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        [ForeignKey("GroupId")]
        public virtual GroupPaymentMaster GroupPaymentMaster { get; set; }

        public virtual List<PaymentDetails> PaymentDetails { get; set; }
    }
}
