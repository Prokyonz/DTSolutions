using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Entities
{
    public class KapanMappingMaster
    {
        public int Sr { get; set; }
        [Key]
        public Guid Id { get; set; }
        public Guid PurchaseMasterId { get; set; }
        public Guid PurchaseDetailsId { get; set; }
        public Guid KapanId { get; set; }
        public string SlipId { get; set; }

    }
}
