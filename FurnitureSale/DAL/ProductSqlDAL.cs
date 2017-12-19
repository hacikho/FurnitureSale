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
        const string SQL_InsertNewProduct = "INSERT INTO product VALUES(@ProductName, @ProductPrice, @ProductDecription, @ProductImageName1, @ProductCategoryID)";

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveNewProduct(Product p)
        {
            throw new NotImplementedException();
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
                        p.Price = Convert.ToInt32(reader["ProductPrice"]);
                        p.Weight = Convert.ToSingle(reader["ProductWeight"]);
                        p.Quantity = Convert.ToInt32(reader["ProductQuantity"]);
                        p.Dimension = Convert.ToString(reader["ProductDimension"]);
                        p.Msrp = Convert.ToInt32(reader["ProductMsrp"]);
                        p.Description = Convert.ToString(reader["ProductDescription"]);
                        p.ImageName1 = Convert.ToString(reader["ProductImage1"]);
                        p.ImageName2 = Convert.ToString(reader["ProductImage2"]);
                        p.ImageName3 = Convert.ToString(reader["ProductImage3"]);

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
    }
}