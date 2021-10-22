using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class ContraEntryDetails
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }
        public string ContraEntryMasterId { get; set; }
        public string FromParty { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        [ForeignKey("ContraEntryMasterId")]
        public virtual ContraEntryMaster ContraEntryMaster{ get; set; }
    }
}
