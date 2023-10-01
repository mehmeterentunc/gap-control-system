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
    internal class SupplierService
    {

        //INSERT
        public void InsertSupplier(Suppliers suppliers)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_TedarikciEkle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Tedarikci", suppliers.Tedarikci);
                    cmd.Parameters.AddWithValue("@username", suppliers.username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //UPDATE
        public void UpdateSupplier(Suppliers suppliers)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open ();
                using (SqlCommand cmd = new SqlCommand("sp_TedarikciGuncelle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TedarikciID", Convert.ToInt32(suppliers.TedarikciID));
                    cmd.Parameters.AddWithValue("@Tedarikci", suppliers.Tedarikci);
                    cmd.Parameters.AddWithValue("@username", suppliers.username);
                    cmd.ExecuteNonQuery();
                }
            }           
        }

        //DELETE
        public void DeleteSupplier(Suppliers suppliers)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open ();
                using (SqlCommand cmd = new SqlCommand("sp_TedarikciSil", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TedarikciID", Convert.ToInt32(suppliers.TedarikciID));
                    cmd.Parameters.AddWithValue("@username", suppliers.username);
                    cmd.ExecuteNonQuery();
                }
            }       
        }
    }
}
