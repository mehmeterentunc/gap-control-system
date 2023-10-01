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
    internal class OrderService
    {
        //INSERT
        public void InsertOrder(Orders order)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_SiparisEkle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CalisanID", order.CalisanID);
                    cmd.Parameters.AddWithValue("@MusteriID", Convert.ToInt32(order.MusteriID));
                    cmd.Parameters.AddWithValue("@UrunID", Convert.ToInt32(order.UrunID));
                    cmd.Parameters.AddWithValue("@username", order.username);

                    cmd.ExecuteNonQuery();
                }
            }           
        }

        //UPDATE
        public void UpdateOrder(Orders order)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_SiparisGuncelle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SiparisID", Convert.ToInt32(order.SiparisID));
                    cmd.Parameters.AddWithValue("@CalisanID", Convert.ToInt32(order.CalisanID));
                    cmd.Parameters.AddWithValue("@MusteriID", Convert.ToInt32(order.MusteriID));
                    cmd.Parameters.AddWithValue("@UrunID", Convert.ToInt32(order.UrunID));
                    cmd.Parameters.AddWithValue("@username", order.username);
                    cmd.ExecuteNonQuery();
                }               
            }
          
        }

        //DELETE
        public void DeleteOrder(Orders order)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_SiparisSil", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SiparisID", Convert.ToInt32(order.SiparisID));
                    cmd.Parameters.AddWithValue("@username", order.username);
                    cmd.ExecuteNonQuery();

                }
            }        
        }
    }
}
