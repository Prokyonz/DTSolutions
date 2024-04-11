using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class DashboardSPModel
    {
        [Column(TypeName = "number(18, 2)")]
        public double? TotalAmount { get; set; }
    }
}
