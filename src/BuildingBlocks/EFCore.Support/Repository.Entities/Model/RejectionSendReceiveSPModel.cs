﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class RejectionSendReceiveSPModel
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string FinancialYearId { get; set; }
        public string SlipNo { get; set; }
        public string KapanId { get; set; }
        public string Kapan { get; set; }
        public string ShapeId { get; set; }
        public string SizeId { get; set; }
        public string Size { get; set; }
        public string PurityId { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal RejectedWeight { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal ReturnCts { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Available { get; set; }
        public double Rate { get; set; }
        public string ProcessType { get; set; }
        public string BrokerageId { get; set; }
        public string PartyId { get; set; }
        public string NumberId { get; set; }
        public string Number { get; set; }
        public string CharniSizeId { get; set; }
        public string PurchaseSaleDetailsId { get; set; }
    }
}
