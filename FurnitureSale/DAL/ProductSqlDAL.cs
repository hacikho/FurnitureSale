using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FurnitureSale.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace FurnitureSale.DAL
{
    public class ProductSqlDAL: IProductDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["FurnitureSaleDB"].ConnectionString;
        const string SQL_GetTop20Products = "SELECT TOP 20 products.* from products";
        const string SQL_InsertNewProduct = "INSERT INTO products VALUES(@ProductName, @ProductPrice, @ProductDescription, @ProductImageName1, @ProductCategoryID)";
        const string SQL_GetProductById = "SELECT products.*, productcategories.* FROM products JOIN productcategories ON products.ProductCategoryID = productcategories.CategoryID WHERE products.ProductID =@id";

        public Product GetProduct(int id)
        {
            Product product = null;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetProductById, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Product p = new Product();
                        p.Id = Convert.ToInt32(reader["ProductID"]);
                        p.Name = Convert.ToString(reader["ProductName"]);
                        p.Price = Convert.ToDecimal(reader["ProductPrice"]);
                        p.Description = Convert.ToString(reader["ProductDescription"]);
                        p.ImageName1 = Convert.ToString(reader["ProductImageName1"]);

                        product = p;
                    }
                }
            }catch(SqlException ex)
            {
                throw;
            }
            return product;
        }
        

        public List<Product> GetLast20Products()
        {
            List<Product> products = new List<Product>();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetTop20Products, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Product p = new Product();
                        p.Id = Convert.ToInt32(reader["ProductID"]);
                        p.Name = Convert.ToString(reader["ProductName"]);
                        p.Price = Convert.ToDecimal(reader["ProductPrice"]);
                        //p.Weight = Convert.ToSingle(reader["ProductWeight"]);
                        //p.Quantity = Convert.ToInt32(reader["ProductQuantity"]);
                        //p.Dimension = Convert.ToString(reader["ProductDimension"]);
                        //p.Msrp = Convert.ToInt32(reader["ProductMsrp"]);
                        p.Description = Convert.ToString(reader["ProductDescription"]);
                        p.ImageName1 = Convert.ToString(reader["ProductImageName1"]);
                        //p.ImageName2 = Convert.ToString(reader["ProductImage2"]);
                        //p.ImageName3 = Convert.ToString(reader["ProductImage3"]);

                        products.Add(p);
                    }
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
            return products;
        }

        public void SaveNewProduct(Product p)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_InsertNewProduct, conn);
                    cmd.Parameters.AddWithValue("@ProductName", p.Name);
                    cmd.Parameters.AddWithValue("@ProductPrice", p.Price);
                    cmd.Parameters.AddWithValue("@ProductDescription", p.Description);
                    if (String.IsNullOrEmpty(p.ImageName1))
                    {
                        cmd.Parameters.AddWithValue("@ProductImageName1", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ProductImageName1", p.ImageName1);
                    }
                    cmd.Parameters.AddWithValue("@ProductCategoryID", p.CategoryID);

                    cmd.ExecuteNonQuery();
                    return;
                }
            }catch(SqlException ex)
            {
                throw;
            }
        }
    }
}