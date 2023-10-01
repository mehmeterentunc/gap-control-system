using GAPtest_Desktop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace GAPtest_Desktop.Services
{
    internal class UserRoleService
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString);
        LogErrorService logErrorService = new LogErrorService();

        //GET USER ROLE
        public Users GetUserRole(string username)
        {
            Users userWithRole = null;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_KullaniciRolGetir", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    userWithRole = new Users
                    {
                        username = dr["username"].ToString(),
                        pw = dr["pw"].ToString(),
                        Employees = Convert.ToBoolean(dr["Employees"]),
                        Products = Convert.ToBoolean(dr["Products"]),
                        Orders = Convert.ToBoolean(dr["Orders"]),
                        Customers = Convert.ToBoolean(dr["Customers"]),
                        Suppliers = Convert.ToBoolean(dr["Suppliers"]),
                        Titles = Convert.ToBoolean(dr["Titles"]),
                        Userss = Convert.ToBoolean(dr["Userss"]),
                        Question = dr["Question"].ToString(),
                        IsActive = Convert.ToBoolean(dr["IsActive"])
                    };
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred");
                LogError log = new LogError();
                log.Log = "Role SERVICE " + ex.Message.ToString();
                logErrorService.InsertLog(log);
            }
            finally
            {
                conn.Close();
            }
            return userWithRole;
        }
    }
}
