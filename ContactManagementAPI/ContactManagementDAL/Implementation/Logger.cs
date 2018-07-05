using ContactManagementDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagementDAL.Implementation
{
    public class Logger : ILogger
    {

        string _connectionString;

        public Logger()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ContactManagement"].ToString();
        }
        public int Log(string exception)
        {
            int newErrorId = 0;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("CMP_CreateExceptionLog", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                   
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@ExceptionMessage", exception));
                        cmd.Parameters.Add(new SqlParameter("@CreatedDate", DateTime.Now));
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            newErrorId = Convert.ToInt32(result);
                        }
                }
            }
            return newErrorId;
        }
    }
}
