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

                        cmd.Parameters.Add("@CompanyId", SqlDbType.VarChar).Value = "ff8d3c9b-957b-46d1-b661-560ae4a2433e";
                        cmd.Parameters.Add("@FinancialYearId", SqlDbType.VarChar).Value = "146c24c5-6663-4f3d-bdfd-80469275c898";
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
