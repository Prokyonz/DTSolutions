using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities.Model
{
    public class ContraSPModel
    {
        public string ContraId { get; set;}
        public string Id { get; set; }
        public string FromPartyId { get; set; }
        public string ToPartyId { get; set; }
        public string FromPartyName { get; set; }
        public string ToPartyName { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? EntryDate { get; set; }
        public int Sr { get; set; }
    }
}
