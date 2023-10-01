using GAPtest_Desktop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAPtest_Desktop.Services
{
    internal class EmployeeService
    {
        
        //INSERT
        public void InsertEmployee(Employees employee)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_CalisanEkle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ad", employee.Ad);
                    cmd.Parameters.AddWithValue("@Soyad", employee.Soyad);
                    cmd.Parameters.AddWithValue("@PozisyonID", Convert.ToInt32(employee.PozisyonID));
                    cmd.Parameters.AddWithValue("@BaslangicTarih", employee.BaslangıcTarih);
                    cmd.Parameters.AddWithValue("@Maas", Convert.ToInt32(employee.Maas));
                    cmd.Parameters.AddWithValue("@Adres", employee.Adres);
                    cmd.Parameters.AddWithValue("@Iletisim", employee.Iletisim);
                    cmd.Parameters.AddWithValue("@Cinsiyet", employee.Cinsiyet);
                    cmd.Parameters.AddWithValue("@username", employee.username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //UPDATE
        public void UpdateEmployee(Employees employee)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_CalisanGuncelle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CalisanlarID", Convert.ToInt32(employee.CalisanlarID));
                    cmd.Parameters.AddWithValue("@Ad", employee.Ad);
                    cmd.Parameters.AddWithValue("@Soyad", employee.Soyad);
                    cmd.Parameters.AddWithValue("PozisyonID", Convert.ToInt32(employee.PozisyonID));
                    cmd.Parameters.AddWithValue("@BaslangicTarih", employee.BaslangıcTarih);
                    cmd.Parameters.AddWithValue("@Maas", Convert.ToInt32(employee.Maas));
                    cmd.Parameters.AddWithValue("@Adres", employee.Adres);
                    cmd.Parameters.AddWithValue("@Iletisim", employee.Iletisim);
                    cmd.Parameters.AddWithValue("@Cinsiyet", employee.Cinsiyet);
                    cmd.Parameters.AddWithValue("@username", employee.username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //DELETE
        public void DeleteEmployee(Employees employee)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_CalisanSil", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CalisanlarID", Convert.ToInt32(employee.CalisanlarID));
                    cmd.Parameters.AddWithValue("@username", employee.username);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
