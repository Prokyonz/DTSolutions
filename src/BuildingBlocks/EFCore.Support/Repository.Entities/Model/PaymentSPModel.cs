﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities.Model
{
    public class PaymentSPModel
    {
        public string Id { get; set; }
        public string GroupId { get; set; }
        public string FromPartyId { get; set; }
        public string ToPartyId { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public decimal Amount { get; set; }
        public string ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public string Remarks { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}