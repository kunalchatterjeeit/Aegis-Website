using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Aegis.DataAccess
{
    public class Product
    {
        public Product()
        {

        }

        public List<Model.Product> Product_GetAll()
        {
            List<Model.Product> products = new List<Model.Product>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Product_GetAll";
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Model.Product()
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                ProductCategoryId = Convert.ToInt32(reader["ProductCategoryId"].ToString()),
                                Name = reader["Name"].ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"].ToString()),
                                SeoUrl = reader["SeoUrl"].ToString(),
                                ProductCategoryName = reader["ProductCategoryName"].ToString(),
                            });
                        }
                    }
                }
            }
            return products;
        }
        public List<Model.Product> Product_GetAllByCategoryId(int productCategoryId)
        {
            List<Model.Product> products = new List<Model.Product>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Product_GetAllByCategoryId";

                    cmd.Parameters.AddWithValue("@ProductCategoryId", productCategoryId);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Model.Product()
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                ProductCategoryId = Convert.ToInt32(reader["ProductCategoryId"].ToString()),
                                Name = reader["Name"].ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"].ToString()),
                                SeoUrl = reader["SeoUrl"].ToString(),
                            });
                        }
                    }
                }
            }
            return products;
        }
        public List<Model.Product> Product_GetAllByCategorySeoUrl(string seoUrl)
        {
            List<Model.Product> products = new List<Model.Product>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Product_GetAllByCategorySeoUrl";

                    cmd.Parameters.AddWithValue("@ProductCategorySeoUrl", seoUrl);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Model.Product()
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                ProductCategoryId = Convert.ToInt32(reader["ProductCategoryId"].ToString()),
                                Name = reader["Name"].ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"].ToString()),
                                SeoUrl = reader["SeoUrl"].ToString(),
                            });
                        }
                    }
                }
            }
            return products;
        }
        public Model.Product Product_GetBySeoUrl(string seoUrl)
        {
            Model.Product product = new Model.Product();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Product_GetBySeoUrl";

                    cmd.Parameters.AddWithValue("@SeoUrl", seoUrl);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product.Id = Convert.ToInt32(reader["Id"].ToString());
                            product.ProductCategoryId = Convert.ToInt32(reader["ProductCategoryId"].ToString());
                            product.Name = reader["Name"].ToString();
                            product.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                            product.SeoUrl = reader["SeoUrl"].ToString();
                        }
                    }
                }
            }
            return product;
        }
        public Model.Product Product_GetById(int id)
        {
            Model.Product productCategories = new Model.Product();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Product_GetById";

                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productCategories.Id = Convert.ToInt32(reader["Id"].ToString());
                            productCategories.ProductCategoryId = Convert.ToInt32(reader["ProductCategoryId"].ToString());
                            productCategories.SeoUrl = reader["SeoUrl"].ToString();
                            productCategories.Name = reader["Name"].ToString();
                            productCategories.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                        }
                    }
                }
            }
            return productCategories;
        }
        public int Product_Save(Model.Product model)
        {
            int retValue = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Product_Save";

                    cmd.Parameters.AddWithValue("@Id", model.Id);
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@SeoUrl", model.SeoUrl);
                    cmd.Parameters.AddWithValue("@ProductCategoryId", model.ProductCategoryId);

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    retValue = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return retValue;
        }
        public int Product_Delete(int id)
        {
            int retValue = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Product_Delete";

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
