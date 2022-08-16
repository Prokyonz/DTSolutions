using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DiamondTradeApp.Services
{
    public class ReportMasterRepository : IReportMasterRepository
    {
        const string connectionString = "Data Source=103.83.81.7;Initial Catalog=karmajew_DiamondTradingLive;Persist Security Info=True;User ID=karmajew_DiamondTrading;Password=DT@123456;";
        public DataTable GetDashboardReports(string companyId, string finYear, int type)
        {
            DataTable dtReports = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetBalanceSheet", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@CompanyId", SqlDbType.VarChar).Value = "Demo Company";
                        cmd.Parameters.Add("@FinancialYearId", SqlDbType.VarChar).Value = "00000000-0000-0000-0000-000000000000";
                        cmd.Parameters.Add("@BalanceSheetType", SqlDbType.Int).Value = 2;

                        con.Open();

                        SqlDataReader dr = cmd.ExecuteReader();
                        dtReports.Load(dr);
                    }
                }
                return dtReports;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
