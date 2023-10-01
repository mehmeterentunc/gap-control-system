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
    internal class ModelService
    {

        //INSERT
        public void InsertModel(Modelss model)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ModelEkle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Model", model.Model);
                    cmd.Parameters.AddWithValue("@KategoriID", Convert.ToInt32(model.KategoriID));
                    cmd.Parameters.AddWithValue("@username", model.username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //UPDATE
        public void UpdateModel(Modelss model)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open ();
                using (SqlCommand cmd = new SqlCommand("sp_ModelGuncelle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ModelID", Convert.ToInt32(model.ModelID));
                    cmd.Parameters.AddWithValue("@Model", model.Model);
                    cmd.Parameters.AddWithValue("@KategoriID", Convert.ToInt32(model.KategoriID));
                    cmd.Parameters.AddWithValue("@username", model.username);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //DELETE
        public void DeleteModel(Modelss model)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open ();
                using (SqlCommand cmd = new SqlCommand("sp_ModelSil", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ModelID", Convert.ToInt32(model.ModelID));
                    cmd.Parameters.AddWithValue("@username", model.username);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
