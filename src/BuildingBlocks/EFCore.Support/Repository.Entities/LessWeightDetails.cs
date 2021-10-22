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
        public string Id { get; set; }
        public string LessWeightId { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal MinWeight { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal MaxWeight { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal LessWeight { get; set; }

        [ForeignKey("LessWeightId")]
        public virtual LessWeightMaster LessWeightMaster { get; set; }
    }
}
