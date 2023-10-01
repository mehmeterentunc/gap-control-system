using GAPtest_Desktop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAPtest_Desktop.Properties;

namespace GAPtest_Desktop.Services
{
    internal class CategoryService
    {

        //INSERT
        public void InsertCategory(Categories category)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_KategoriEkle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Kategori", category.Kategori);
                    cmd.Parameters.AddWithValue("@username", category.username);
                    cmd.ExecuteNonQuery();
                }
            }             
        }

        //UPDATE
        public void UpdateCategory(Categories category)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open ();
                using (SqlCommand cmd = new SqlCommand("sp_KategoriGuncelle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@KategoriID", Convert.ToInt32(category.KategoriID));
                    cmd.Parameters.AddWithValue("@Kategori", category.Kategori);
                    cmd.Parameters.AddWithValue("@username", category.username);
                    cmd.ExecuteNonQuery();
                }
            }

        }

        //DELETE
        public void DeleteCategory(Categories category)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_KategoriSil", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@KategoriID", Convert.ToInt32(category.KategoriID));
                    cmd.Parameters.AddWithValue("@username", category.username);
                    cmd.ExecuteNonQuery();
                }
            }
                           
        }
    }
}
