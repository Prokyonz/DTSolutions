using System;
using System.Collections.Generic;
using System.Text;

namespace DiamondTradeApp.Services
{
   public interface IUserMasterRepository
    {
        bool Login(string username, string password);
        bool ChangePassword(string username, string currentPass, string newPass);
    }
}
