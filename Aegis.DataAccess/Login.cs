using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aegis.DataAccess
{
    public class Login
    {
        public string AuthenticateUser(string UserName)
        {
            string password = string.Empty;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CrmConStr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "GetUserNameAndPass";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeCode", UserName);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            password = dr["Password"].ToString();
                        }
                        con.Close();
                    }
                    return password;
                }
            }
        }
    }
}
