using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Entities
{
    public class TransferMaster
    {
        public int Sr { get; }
        [Key]

        public string Id { get; set; }
        public int JangadNo { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string TRansferById { get; set; }
        public string Remark { get; set; }
        public string CompanyId { get; set; }
        public string FinancialYearId { get; set; }
        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }
        public byte[] Image3 { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Message { get; set; }
        public int ApprovalType { get; set; }
    }
}
