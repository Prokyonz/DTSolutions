using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class ChildLedgerSPModel
    {
        public string EntryType { get; set; }
        public string FromPartyId { get; set; }
        public string FromPartyName { get; set; }
        public string ToPartyId { get; set; }
        public string ToPartyName { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Debit { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Credit { get; set; }
        public DateTime? Date { get; set; }
        public string SlipNo { get; set; }
        public string Remarks { get; set; }
    }
}
