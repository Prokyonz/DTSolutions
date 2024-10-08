﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class GroupPaymentMaster
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string FinancialYearId { get; set; }
        public int CrDrType { get; set; } // 0 -> Debit, 1 -> Credit
        public string ToPartyId { get; set; } //Bank or Cash PartyId
        public int BillNo { get; set; }
        public string Remarks { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Message { get; set; }
        public int ApprovalType { get; set; }
        public string EntryDate { get; set; }
        public string EntryTime { get; set; }

        public virtual List<PaymentMaster> PaymentMasters { get; set; }
        public virtual List<PaymentDetails> PaymentDetails { get; set; }
    }
}
