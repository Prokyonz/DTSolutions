using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities.Model
{
    public class WeeklyPurchaseReport
    {
        public string WeekNo { get; set; }
        public string Period { get; set; }
        public double Amount { get; set; }
        public string Week_Start_Date { get; set; }
        public string Week_End_Date { get; set; }
    }
}
