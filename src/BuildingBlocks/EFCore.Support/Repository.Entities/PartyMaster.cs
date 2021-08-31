using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class PartyMaster
    {
        public int Sr { get; set; }
        [Key]
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string MobileNo { get; set; }
        public string OfficeNo { get; set; }
        public string GSTNo { get; set; }
        public string AadharCardNo { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        [ForeignKey("CompanyId")]
        public virtual CompanyMaster CompanyMaster { get; set; }
    }
}
