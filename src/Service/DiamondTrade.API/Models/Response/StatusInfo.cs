using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondTrade.API.Models.Response
{
    public class StatusInfo
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

    }
}
