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
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public Guid FromPartyId { get; set; }
        public decimal Amount { get; set; }
        public int CrDrType { get; set; } // 0 -> Debit, 1 -> Credit
        public string ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        [ForeignKey("GroupId")]
        public virtual GroupPaymentMaster GroupPaymentMaster { get; set; }

        public virtual List<PaymentDetails> PaymentDetails { get; set; }
    }
}
