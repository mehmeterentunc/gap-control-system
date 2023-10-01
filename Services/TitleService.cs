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
    internal class TitleService
    {
        //INSERT
        public void InsertTitle(Titles title)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_PozisyonEkle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Pozisyon", title.Pozisyon);
                    cmd.Parameters.AddWithValue("username", title.username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //UPDATE
        public void UpdateTitle(Titles title)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_PozisyonGuncelle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PozisyonID", Convert.ToInt32(title.PozisyonID));
                    cmd.Parameters.AddWithValue("@Pozisyon", title.Pozisyon);
                    cmd.Parameters.AddWithValue("username", title.username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //DELETE
        public void DeleteTitle(Titles title)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_PozisyonSil", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PozisyonID", Convert.ToInt32(title.PozisyonID));
                    cmd.Parameters.AddWithValue("username", title.username);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
