using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class UserMaster
    {
        public int Sr { get; }
        [Key]
        public string Id { get; set; }
        public string UserCode { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int UserType { get; set; }
        public string BrokerageId { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string MobileNo { get; set; }
        public string HomeNo { get; set; }
        public string ReferenceBy { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AadharCardNo { get; set; }
        public string DepartmentName { get; set; }
        public string Designation { get; set; }
        public DateTime DateOfJoin { get; set; }
        public DateTime DateOfEnd { get; set; }
        public bool IsActive { get; set; }        
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string IFSCCode { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }        
    }
}
