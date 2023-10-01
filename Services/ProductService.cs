using GAPtest_Desktop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAPtest_Desktop.Services
{
    internal class ProductService
    {

        //INSERT
        public void InsertProduct(Products product)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_UrunEkle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Urun", product.Urun);
                    cmd.Parameters.AddWithValue("@ModelID", Convert.ToInt32(product.ModelID));
                    cmd.Parameters.AddWithValue("@Fiyat", Convert.ToInt32(product.Fiyat));
                    cmd.Parameters.AddWithValue("@StokSayısı", Convert.ToInt32(product.StokSayısı));
                    cmd.Parameters.AddWithValue("@TedarikciID", Convert.ToInt32(product.TedarikciID));
                    cmd.Parameters.AddWithValue("@username", product.username);
                    cmd.ExecuteNonQuery();
                }
            }        
        }

        //UPDATE
        public void UpdateProduct(Products product)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_UrunGuncelle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UrunID", Convert.ToInt32(product.UrunID));
                    cmd.Parameters.AddWithValue("@Urun", product.Urun);
                    cmd.Parameters.AddWithValue("@ModelID", Convert.ToInt32(product.ModelID));
                    cmd.Parameters.AddWithValue("@Fiyat", Convert.ToInt32(product.Fiyat));
                    cmd.Parameters.AddWithValue("@StokSayısı", Convert.ToInt32(product.StokSayısı));
                    cmd.Parameters.AddWithValue("@TedarikciID", Convert.ToInt32(product.TedarikciID));
                    cmd.Parameters.AddWithValue("@username", product.username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //DELETE
        public void DeleteProduct(Products products)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_UrunSil", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UrunID", Convert.ToInt32(products.UrunID));
                    cmd.Parameters.AddWithValue("@username", products.username);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
