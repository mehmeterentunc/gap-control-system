using GAPtest_Desktop.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GAPtest_Desktop.Services
{
    internal class LogErrorService
    {
        public void InsertLog(LogError log)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GapConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_LogHataEkle", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Log", log.Log);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
