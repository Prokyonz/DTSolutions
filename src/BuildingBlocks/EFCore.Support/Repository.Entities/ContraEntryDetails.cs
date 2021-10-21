using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class ContraEntryDetails
    {
        public int Sr { get; set; }
        [Key]
        public Guid Id { get; set; }
        public Guid ContraEntryMasterId { get; set; }
        public Guid FromParty { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        [ForeignKey("ContraEntryMasterId")]
        public virtual ContraEntryMaster ContraEntryMaster{ get; set; }
    }
}
