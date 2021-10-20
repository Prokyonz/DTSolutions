using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class SlipTransferEntry
    {
        public int Sr { get; set; }
        [Key]
        public Guid Id { get; set; }
        public Guid PurchaseMasterId { get; set; }
        public DateTime SlipTransferEntryDate { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        [ForeignKey("PurchaseMasterId")]
        public PurchaseMaster PurchaseMaster { get; set; }
    }
}
