using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class UserMaster
    {
        [Key]
        public int Id { get; set; }        
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public int Type { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string MobileNo { get; set; }
        public string HomeNo { get; set; }
        public string ReferenceBy { get; set; }
        public string AadharCardNo { get; set; }
        public bool IsDetele { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }        

        [ForeignKey("BranchId")]
        public BranchMaster BranchMaster { get; set; }
    }
}
