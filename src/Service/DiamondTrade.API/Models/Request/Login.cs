using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondTrade.API.Models.Request
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
