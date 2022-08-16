using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DiamondTradeApp.Services
{
    public interface IReportMasterRepository
    {
        DataTable GetDashboardReports(string companyId, string finYear, int type);
    }
}
