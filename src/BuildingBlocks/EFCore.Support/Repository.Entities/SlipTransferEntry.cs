using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class SlipTransferEntry
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }
        public string PurchaseMasterId { get; set; }
        public DateTime SlipTransferEntryDate { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        [ForeignKey("PurchaseMasterId")]
        public PurchaseMaster PurchaseMaster { get; set; }
    }
}
