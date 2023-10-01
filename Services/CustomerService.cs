using GAPtest_Desktop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GAPtest_Desktop.Services
{
    internal class CustomerService
    {
        //INSERT
        public void InsertCustomer(Customers customer)
        {
            using(SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_MusteriEkle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ad", customer.Ad);
                    cmd.Parameters.AddWithValue("@Soyad", customer.Soyad);
                    cmd.Parameters.AddWithValue("Iletisim", customer.Iletisim);
                    cmd.Parameters.AddWithValue("@Cinsiyet", customer.Cinsiyet);
                    cmd.Parameters.AddWithValue("@Adres", customer.Adres);
                    cmd.Parameters.AddWithValue("username", customer.username);
                    cmd.ExecuteNonQuery();
                }
            }
 
        }

        //UPDATE
        public void UpdateCustomer(Customers customer)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString)) 
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_MusteriGuncelle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MusteriID", Convert.ToInt32(customer.MusteriID));
                    cmd.Parameters.AddWithValue("@Ad", customer.Ad);
                    cmd.Parameters.AddWithValue("@Soyad", customer.Soyad);
                    cmd.Parameters.AddWithValue("@Iletisim", customer.Iletisim);
                    cmd.Parameters.AddWithValue("@Cinsiyet", customer.Cinsiyet);
                    cmd.Parameters.AddWithValue("@Adres", customer.Adres);
                    cmd.Parameters.AddWithValue("username", customer.username);
                    cmd.ExecuteNonQuery();
                }                       
            }
           
        }

        //DELETE
        public void DeleteCustomer(Customers customer)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_MusteriSil", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MusteriID", Convert.ToInt32(customer.MusteriID));
                    cmd.Parameters.AddWithValue("username", customer.username);
                    cmd.ExecuteNonQuery();
                }
            }                                  
        }
    }
}
