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
    public class ProductFeature
    {
        public ProductFeature()
        {

        }

        public List<Model.ProductFeature> ProductFeature_GetByProductId(int productId)
        {
            List<Model.ProductFeature> productCategories = new List<Model.ProductFeature>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ProductFeature_GetByProductId";
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productCategories.Add(new Model.ProductFeature()
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                ProductId = Convert.ToInt32(reader["ProductId"].ToString()),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"].ToString())
                            });
                        }
                    }
                }
            }
            return productCategories;
        }
        public Model.ProductFeature ProductFeature_GetById(int id)
        {
            Model.ProductFeature productCategories = new Model.ProductFeature();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ProductFeature_GetById";

                    cmd.Parameters.AddWithValue("@Id", id);

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productCategories.Id = Convert.ToInt32(reader["Id"].ToString());
                            productCategories.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
                            productCategories.Name = reader["Name"].ToString();
                            productCategories.Description = reader["Description"].ToString();
                            productCategories.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                        }
                    }
                }
            }
            return productCategories;
        }
        public int ProductFeature_Save(Model.ProductFeature model)
        {
            int retValue = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ProductFeature_Save";

                    cmd.Parameters.AddWithValue("@Id", model.Id);
                    cmd.Parameters.AddWithValue("@ProductId", model.ProductId);
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@Description", model.Description);

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    retValue = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return retValue;
        }
        public int ProductFeature_Delete(int id)
        {
            int retValue = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ProductFeature_Delete";

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
