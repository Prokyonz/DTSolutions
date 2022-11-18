using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DiamondTradeApp.Services
{
    public class UserMasterRepository : IUserMasterRepository
    {
        const string connectionString = "Data Source=103.83.81.7;Initial Catalog=karmajew_DiamondTradingLive;Persist Security Info=True;User ID=karmajew_DiamondTrading;Password=DT@123456;";
        public UserMasterRepository()
        {
        }

        public string Login(string username, string password)
        {
            string userId = "";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("Select top 1 * from UserMaster Where UserName=@UserName AND Password=@Password", sqlConnection);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    userId = dt.Rows[0]["ID"].ToString();
                }

                return userId;
            }
        }

        public bool ChangePassword(string username, string currentPass, string newPass)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand("Select top 1 * from UserMaster Where UserName=@UserName AND Password=@Password", sqlConnection);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", currentPass);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    SqlCommand updatePassCommand = new SqlCommand("UPDATE UserMaster SET Password = @NewPass WHERE UserName = @UserName AND Password = @CurrentPassword", sqlConnection);
                    updatePassCommand.Parameters.AddWithValue("@NewPass", newPass);
                    updatePassCommand.Parameters.AddWithValue("@UserName", username);
                    updatePassCommand.Parameters.AddWithValue("@CurrentPassword", currentPass);
                    int updated = updatePassCommand.ExecuteNonQuery();

                    if (updated > 0)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
        }
    }
}
