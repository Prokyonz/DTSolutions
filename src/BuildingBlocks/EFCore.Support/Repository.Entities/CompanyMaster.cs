using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class CompanyMaster
    {
        public int Sr { get; }
        [Key]
        public string Id { get; set; }
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
        public string Type { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        //Get list of Child Records.
        public virtual List<BranchMaster> BranchMasters { get; set; }
        public virtual List<PartyMaster> PartyMasters { get; set; }
        public virtual List<CompanyOptions> CompanyOptions { get; set; }
    }

    public class CompanyOptions
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }

        [ForeignKey("CompanyMaster")]
        public string CompanyMasterId { get; set; }
        public bool IsPurchase { get; set; }
        public bool IsSales { get; set; }
        public string PermissionName { get; set; }
        public bool PermissionStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
