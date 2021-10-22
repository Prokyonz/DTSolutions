using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class BranchMaster
    {
        public int Sr { get; }
        [Key]
        public string Id { get; set; }        
        public string CompanyId { get; set; }
        public string LessWeightId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string MobileNo { get; set; }
        public string OfficeNo { get; set; }
        public string Details { get; set; }
        public string TermsCondition { get; set; }
        public string GSTNo { get; set; }
        public string PanCardNo { get; set; }
        public string RegistrationNo { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal CVDWeight{ get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal TipWeight { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        [ForeignKey("CompanyId")]
        public virtual CompanyMaster CompanyMaster { get; set; }

        //Collection properties
        public virtual List<UserMaster> UserMasters { get; set; }

    }
}
