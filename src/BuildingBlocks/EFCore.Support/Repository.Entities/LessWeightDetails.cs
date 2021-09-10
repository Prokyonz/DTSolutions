using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class LessWeightDetails
    {
        public int Sr { get; }
        [Key]
        public Guid Id { get; set; }
        public Guid LessWeightId { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal MinWeight { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal MaxWeight { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal LessWeight { get; set; }

        [ForeignKey("LessWeightId")]
        public LessWeightMaster LessWeightMaster { get; set; }
    }
}
