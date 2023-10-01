using GAPtest_Desktop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace GAPtest_Desktop.Services
{
    internal class UserChangePasswordService
    {

        //CHANGE PASSWORD
        public bool ChangeUserPassword(Users user )
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_KullaniciSifreDegistir", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", user.username);
                    cmd.Parameters.AddWithValue("@pw", user.pw);
                    cmd.Parameters.AddWithValue("@Question", user.Question);

                    bool result = Convert.ToBoolean(cmd.ExecuteScalar());
                    return Convert.ToBoolean(result);
                }
            }
                      
        }

        //PASSIVE
        public void PassiveUser(Users user)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_KullaniciPassive", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("username", user.username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //ACTIVE
        public void ActiveUser(Users user)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_KullaniciActive", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("username", user.username);
                    cmd.ExecuteNonQuery();
                }
            }

        }
    }
}
