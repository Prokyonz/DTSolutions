using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class CompanyMaster
    {
        public int Sr { get; }
        [Key]
        public Guid Id { get; set; }
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
        public Guid? Type { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        //Get list of Child Records.
        public virtual List<BranchMaster> BranchMasters { get; set; }
        public virtual List<PartyMaster> PartyMasters { get; set; }
    }
}
