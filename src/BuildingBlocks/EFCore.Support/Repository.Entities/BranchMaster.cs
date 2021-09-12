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
        public Guid Id { get; set; }        
        public Guid CompanyId { get; set; }
        public Guid? LessWeightId { get; set; }
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
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        [ForeignKey("CompanyId")]
        public virtual CompanyMaster CompanyMaster { get; set; }

        //Collection properties
        public virtual List<UserMaster> UserMasters { get; set; }

    }
}
