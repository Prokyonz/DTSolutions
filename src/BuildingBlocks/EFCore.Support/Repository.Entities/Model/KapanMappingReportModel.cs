using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class KapanMappingReportModel
    {
        public string Id { get; set; }
        public int Sr { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string FinancialYearId { get; set; }
        public string SlipNo { get; set; }
        public string KapanId { get; set; }
        public string Name { get; set; }
        public string PurchaseDetailsId { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Weight { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
