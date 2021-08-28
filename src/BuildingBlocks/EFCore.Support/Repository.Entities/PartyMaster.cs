using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class PartyMaster
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }
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
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [ForeignKey("CompanyId")]
        public virtual CompanyMaster CompanyMaster { get; set; }
    }
}
