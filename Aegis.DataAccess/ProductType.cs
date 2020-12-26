using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Aegis.DataAccess
{
    public class ProductType
    {
        public List<Model.ProductType> ProductType_GetAll()
        {
            List<Model.ProductType> productTypes = new List<Model.ProductType>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ProductType_GetAll";
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productTypes.Add(new Model.ProductType()
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"].ToString()),
                                SeoUrl = reader["SeoUrl"].ToString(),
                                ContentPath = reader["ContentPath"].ToString()
                            });
                        }
                    }
                }
            }
            return productTypes;
        }
        public Model.ProductType ProductType_GetById(int id)
        {
            Model.ProductType productType = new Model.ProductType();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ProductType_GetById";

                    cmd.Parameters.AddWithValue("@Id", id);

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productType.Id = Convert.ToInt32(reader["Id"].ToString());
                            productType.Name = reader["Name"].ToString();
                            productType.Description = reader["Description"].ToString();
                            productType.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                            productType.SeoUrl = reader["SeoUrl"].ToString();
                        }
                    }
                }
            }
            return productType;
        }
        public int ProductType_Save(Model.ProductType model)
        {
            int retValue = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ProductType_Save";

                    cmd.Parameters.AddWithValue("@Id", model.Id);
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@Description", model.Description);
                    cmd.Parameters.AddWithValue("@SeoUrl", model.SeoUrl);

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    retValue = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return retValue;
        }
        public int ProductType_Delete(int id)
        {
            int retValue = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ProductType_Delete";

                    cmd.Parameters.AddWithValue("@Id", id);

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    retValue = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return retValue;
        }
    }
}
