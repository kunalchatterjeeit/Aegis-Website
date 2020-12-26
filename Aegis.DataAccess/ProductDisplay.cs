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
    public class ProductDisplay
    {
        public ProductDisplay()
        {

        }

        public List<Model.ProductDisplay> ProductDisplay_GetByProductId(int productId)
        {
            List<Model.ProductDisplay> productCategories = new List<Model.ProductDisplay>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ProductDisplay_GetByProductId";
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productCategories.Add(new Model.ProductDisplay()
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                ProductId = Convert.ToInt32(reader["ProductId"].ToString()),
                                ContentTypeId = Convert.ToInt32(reader["ContentTypeId"].ToString()),
                                Name = reader["Name"].ToString(),
                                ContentPath = reader["ContentPath"].ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"].ToString())
                            });
                        }
                    }
                }
            }
            return productCategories;
        }
        public Model.ProductDisplay ProductDisplay_GetById(int id)
        {
            Model.ProductDisplay productCategories = new Model.ProductDisplay();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ProductDisplay_GetById";

                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productCategories.Id = Convert.ToInt32(reader["Id"].ToString());
                            productCategories.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
                            productCategories.ContentTypeId = Convert.ToInt32(reader["ContentTypeId"].ToString());
                            productCategories.Name = reader["Name"].ToString();
                            productCategories.ContentPath = reader["ContentPath"].ToString();
                            productCategories.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                        }
                    }
                }
            }
            return productCategories;
        }
        public int ProductDisplay_Save(Model.ProductDisplay model)
        {
            int retValue = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ProductDisplay_Save";

                    cmd.Parameters.AddWithValue("@Id", model.Id);
                    cmd.Parameters.AddWithValue("@ProductId", model.ProductId);
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@ContentPath", model.ContentPath);

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    retValue = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return retValue;
        }
        public int ProductDisplay_Delete(int id)
        {
            int retValue = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ProductDisplay_Delete";

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
