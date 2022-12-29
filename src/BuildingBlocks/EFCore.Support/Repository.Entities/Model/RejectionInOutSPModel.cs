using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class RejectionInOutSPModel
    {
        public string Id { get; set; }
        public int SrNo { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public DateTime? EntryDate { get; set; }
        public string PartyId { get; set; }
        public string PartyName { get; set; }
        public string BrokerageId { get; set; }
        public string BrokerName { get; set; }
        public string FinancialYearId { get; set; }
        public int TransType { get; set; } //send/Boil/Charni/Gala/Number receive-2 or receive/Sales-1
        public string SlipNo { get; set; }
        public string SizeId { get; set; }
        public string SizeName { get; set; }
        public string PurityId { get; set; }
        public string PurityName { get; set; }
        public string CharniSizeId { get; set; }
        public string CharniSizeName { get; set; }
        public string GalaSizeId { get; set; }
        public string GalaSizeName { get; set; }
        public string NumberSizeId { get; set; }
        public string NumberSizeName { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public double Rate { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalCarat { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Amount { get; set; }
        //public byte?[] Image1 { get; set; }
        //public byte?[] Image2 { get; set; }
        //public byte?[] Image3 { get; set; }
        public string Remarks { get; set; }
    }
}
