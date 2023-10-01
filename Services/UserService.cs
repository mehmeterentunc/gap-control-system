using GAPtest_Desktop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAPtest_Desktop.Services
{
    internal class UserService
    {

        //INSERT
        public void InsertUser(Users user)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_KullaniciEkle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", user.username);
                    cmd.Parameters.AddWithValue("@pw", user.pw);
                    cmd.Parameters.AddWithValue("@Employees", user.Employees);
                    cmd.Parameters.AddWithValue("@Products", user.Products);
                    cmd.Parameters.AddWithValue("@Orders", user.Orders);
                    cmd.Parameters.AddWithValue("@Customers", user.Customers);
                    cmd.Parameters.AddWithValue("@Suppliers", user.Suppliers);
                    cmd.Parameters.AddWithValue("@Titles", user.Titles);
                    cmd.Parameters.AddWithValue("@Userss", user.Userss);
                    cmd.Parameters.AddWithValue("@Question", user.Question);
                    cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                    cmd.Parameters.AddWithValue("@username1", user.username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //UPDATE
        public void UpdateUser(Users user)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_KullaniciGuncelle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@KullaniciID", Convert.ToInt32(user.KullaniciID));
                    cmd.Parameters.AddWithValue("@username", user.username);
                    cmd.Parameters.AddWithValue("@pw", user.pw);
                    cmd.Parameters.AddWithValue("@Employees", user.Employees);
                    cmd.Parameters.AddWithValue("@Products", user.Products);
                    cmd.Parameters.AddWithValue("@Orders", user.Orders);
                    cmd.Parameters.AddWithValue("@Customers", user.Customers);
                    cmd.Parameters.AddWithValue("@Suppliers", user.Suppliers);
                    cmd.Parameters.AddWithValue("@Titles", user.Titles);
                    cmd.Parameters.AddWithValue("@Userss", user.Userss);
                    cmd.Parameters.AddWithValue("@Question", user.Question);
                    cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                    cmd.Parameters.AddWithValue("@username1", user.username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //DELETE
        public void DeleteUser(Users user)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_KullaniciSil", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@KullaniciID", Convert.ToInt32(user.KullaniciID));
                    cmd.Parameters.AddWithValue("@username1", user.username1);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
