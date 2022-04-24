using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class JangadPrintDetailModel
    {
        public Int64 SNo { get; set; }
        public int SrNo { get; set; }
        public string Date { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string GSTNo { get; set; }
        public string PartyName { get; set; }
        public string BrokerName { get; set; }
        public string Size { get; set; }
        public string Remarks { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public double Rate { get; set; }
        public double Amount { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalCts { get; set; }
    }
}
