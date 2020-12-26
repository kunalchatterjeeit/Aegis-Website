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
    public class ProductCategory
    {
        public ProductCategory()
        {

        }
        public List<Model.ProductCategory> ProductCategory_GetAll()
        {
            List<Model.ProductCategory> productCategories = new List<Model.ProductCategory>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ProductCategory_GetAll";
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productCategories.Add(new Model.ProductCategory()
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                ProductTypeId = Convert.ToInt32(reader["ProductTypeId"].ToString()),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"].ToString()),
                                SeoUrl = reader["SeoUrl"].ToString(),
                                ProductTypeName = reader["ProductTypeName"].ToString(),
                            });
                        }
                    }
                }
            }
            return productCategories;
        }
        public Model.ProductCategory ProductCategory_GetById(int id)
        {
            Model.ProductCategory productCategories = new Model.ProductCategory();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ProductCategory_GetById";

                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productCategories.Id = Convert.ToInt32(reader["Id"].ToString());
                            productCategories.ProductTypeId = Convert.ToInt32(reader["ProductTypeId"].ToString());
                            productCategories.Name = reader["Name"].ToString();
                            productCategories.Description = reader["Description"].ToString();
                            productCategories.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                            productCategories.SeoUrl = reader["SeoUrl"].ToString();
                        }
                    }
                }
            }
            return productCategories;
        }
        public int ProductCategory_Save(Model.ProductCategory model)
        {
            int retValue = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ProductCategory_Save";

                    cmd.Parameters.AddWithValue("@Id", model.Id);
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@Description", model.Description);
                    cmd.Parameters.AddWithValue("@SeoUrl", model.SeoUrl);
                    cmd.Parameters.AddWithValue("@ProductTypeId", model.ProductTypeId);

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    retValue = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return retValue;
        }
        public int ProductCategory_Delete(int id)
        {
            int retValue = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ProductCategory_Delete";

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
