using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class PaymentPSSlipDetails
    {
        public string PurchaseId { get; set; }
        public string Date { get; set; }
        public string PartyId { get; set; }
        public string Party { get; set; }
        public long SlipNo { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string FinancialYearId { get; set; }
        public string Year { get; set; }
        public double GrossTotal { get; set; }
        public double RemainAmount { get; set; }
    }
}
