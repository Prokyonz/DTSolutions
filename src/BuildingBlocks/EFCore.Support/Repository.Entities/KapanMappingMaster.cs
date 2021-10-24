﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class KapanMappingMaster
    {
        public int Sr { get; set; }
        [Key]
        public string Id { get; set; }
        public string PurchaseMasterId { get; set; }
        public string PurchaseDetailsId { get; set; }
        public string KapanId { get; set; }
        public string SlipId { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Weight { get; set; }
    }
}