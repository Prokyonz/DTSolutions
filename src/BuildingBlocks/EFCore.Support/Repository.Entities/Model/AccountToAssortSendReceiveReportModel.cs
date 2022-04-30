using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class AccountToAssortSendReceiveReportModel
    {
        public string Id { get; set; }
        public string ChildId { get; set; }
        public int Sr { get; set; }
        public string Department { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string FinancialYearId { get; set; }
        public DateTime? EntryDate { get; set; }
        public string FromPartyId { get; set; }
        public string FromPartyName { get; set; }
        public string ToPartyId { get; set; }
        public string ToPartyName { get; set; }        
        public string KapanId { get; set; }
        public string KapanName { get; set; }
        public int AccountToAssortType { get; set; }
        public string Remarks { get; set; }
        public string SlipNo { get; set; }
        public string SizeId { get; set; }
        public string SizeName { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Weight { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal AssignWeight { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
