using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class RejectionInOutMaster
    {
        public int Sr { get; }
        [Key]
        public string Id { get; set; }
        public int SrNo { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string EntryDate { get; set; }
        public string PartyId { get; set; }
        public string BrokerageId { get; set; }
        public string FinancialYearId { get; set; }
        public int TransType { get; set; } //send or receive
        public string SlipNo { get; set; }
        public string SizeId { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Rate { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TotalCarat { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Amount { get; set; }
        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }
        public byte[] Image3 { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
