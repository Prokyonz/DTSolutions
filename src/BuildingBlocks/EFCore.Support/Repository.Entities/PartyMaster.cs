using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class PartyMaster
    {
        public int Sr { get;  }
        [Key]
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string BrokerageId { get; set; }
        public int Type { get; set; }
        public int SubType { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string MobileNo { get; set; }
        public string OfficeNo { get; set; }
        public string GSTNo { get; set; }
        public string AadharCardNo { get; set; }
        public string PancardNo { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Salary { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal OpeningBalance { get; set; }
        public bool IsDelete { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        [ForeignKey("CompanyId")]
        public virtual CompanyMaster CompanyMaster { get; set; }
    }
}
