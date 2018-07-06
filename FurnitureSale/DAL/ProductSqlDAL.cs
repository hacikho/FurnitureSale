using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FurnitureSale.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace FurnitureSale.DAL
{
    public class ProductSqlDAL: IProductDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["FurnitureSaleDB"].ConnectionString;
        const string SQL_GetTop20Products = "SELECT TOP 10 products.* from products";
        const string SQL_GetAllProducts = "SELECT products.* from products";
        const string SQL_InsertNewProduct = "INSERT INTO products VALUES(@ProductName, @ProductPrice, @ProductDescription, @ProductImageName1, @ProductImageName2, @ProductImageName3, @ProductCategoryID, @ProductQuantity)";
        const string SQL_GetProductById = "SELECT products.*, productcategories.* FROM products JOIN productcategories ON products.ProductCategoryID = productcategories.CategoryID WHERE products.ProductID =@id";
        const string SQL_EditProduct = "UPDATE products set ProductName = @ProductName, ProductPrice = @ProductPrice, ProductDescription = @ProductDescription, ProductImageName1 = @ProductImageName1, ProductCategoryID = @ProductCategoryID, " +
            "ProductQuantity = @ProductQuantity WHERE ProductID = @ProductID";
        const string SQL_GetLivingRoomProducts = "SELECT products.* FROM products WHERE products.ProductCategoryID = 1";
        const string SQL_GetBedRoomProducts = "SELECT products.* FROM products WHERE products.ProductCategoryID = 2";
        const string SQL_GetDiningRoomProducts = "SELECT products.* FROM products WHERE products.ProductCategoryID = 3";
        const string SQL_KitchenProducts = "SELECT products.* FROM products WHERE products.ProductCategoryID = 4";
        const string SQL_BabiesKidsProducts = "SELECT products.* FROM products WHERE products.ProductCategoryID = 5";




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
                        p.ImageName2 = Convert.ToString(reader["ProductImageName2"]);
                        p.ImageName3 = Convert.ToString(reader["ProductImageName3"]);
                        p.CategoryID = Convert.ToInt32(reader["ProductCategoryID"]);
                        p.Quantity = Convert.ToInt32(reader["ProductQuantity"]);
                        product = p;
                    }
                }
            }catch(SqlException ex)
            {
                throw;
            }
            return product;
        }

        public List<Product> GetLivingRoomProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetLivingRoomProducts, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Product p = new Product();
                        p.Id = Convert.ToInt32(reader["ProductID"]);
                        p.Name = Convert.ToString(reader["ProductName"]);
                        p.Price = Convert.ToDecimal(reader["ProductPrice"]);
                        p.Description = Convert.ToString(reader["ProductDescription"]);
                        p.ImageName1 = Convert.ToString(reader["ProductImageName1"]);
                        p.ImageName2 = Convert.ToString(reader["ProductImageName2"]);
                        p.ImageName3 = Convert.ToString(reader["ProductImageName3"]);
                        p.CategoryID = Convert.ToInt32(reader["ProductCategoryID"]);
                        p.Quantity = Convert.ToInt32(reader["ProductQuantity"]);

                        products.Add(p);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return products;
        }


        public List<Product> GetBedRoomProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetBedRoomProducts, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Product p = new Product();
                        p.Id = Convert.ToInt32(reader["ProductID"]);
                        p.Name = Convert.ToString(reader["ProductName"]);
                        p.Price = Convert.ToDecimal(reader["ProductPrice"]);
                        p.Description = Convert.ToString(reader["ProductDescription"]);
                        p.ImageName1 = Convert.ToString(reader["ProductImageName1"]);
                        p.ImageName2 = Convert.ToString(reader["ProductImageName2"]);
                        p.ImageName3 = Convert.ToString(reader["ProductImageName3"]);
                        p.CategoryID = Convert.ToInt32(reader["ProductCategoryID"]);
                        p.Quantity = Convert.ToInt32(reader["ProductQuantity"]);

                        products.Add(p);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return products;
        }



        public List<Product> GetDiningRoomProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetDiningRoomProducts, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Product p = new Product();
                        p.Id = Convert.ToInt32(reader["ProductID"]);
                        p.Name = Convert.ToString(reader["ProductName"]);
                        p.Price = Convert.ToDecimal(reader["ProductPrice"]);
                        p.Description = Convert.ToString(reader["ProductDescription"]);
                        p.ImageName1 = Convert.ToString(reader["ProductImageName1"]);
                        p.ImageName2 = Convert.ToString(reader["ProductImageName2"]);
                        p.ImageName3 = Convert.ToString(reader["ProductImageName3"]);
                        p.CategoryID = Convert.ToInt32(reader["ProductCategoryID"]);
                        p.Quantity = Convert.ToInt32(reader["ProductQuantity"]);

                        products.Add(p);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return products;
        }


        public List<Product> GetKitchenProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetDiningRoomProducts, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Product p = new Product();
                        p.Id = Convert.ToInt32(reader["ProductID"]);
                        p.Name = Convert.ToString(reader["ProductName"]);
                        p.Price = Convert.ToDecimal(reader["ProductPrice"]);
                        p.Description = Convert.ToString(reader["ProductDescription"]);
                        p.ImageName1 = Convert.ToString(reader["ProductImageName1"]);
                        p.ImageName2 = Convert.ToString(reader["ProductImageName2"]);
                        p.ImageName3 = Convert.ToString(reader["ProductImageName3"]);
                        p.CategoryID = Convert.ToInt32(reader["ProductCategoryID"]);
                        p.Quantity = Convert.ToInt32(reader["ProductQuantity"]);

                        products.Add(p);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return products;
        }


        public List<Product> GetBabiesKidsProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_BabiesKidsProducts, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Product p = new Product();
                        p.Id = Convert.ToInt32(reader["ProductID"]);
                        p.Name = Convert.ToString(reader["ProductName"]);
                        p.Price = Convert.ToDecimal(reader["ProductPrice"]);
                        p.Description = Convert.ToString(reader["ProductDescription"]);
                        p.ImageName1 = Convert.ToString(reader["ProductImageName1"]);
                        p.ImageName2 = Convert.ToString(reader["ProductImageName2"]);
                        p.ImageName3 = Convert.ToString(reader["ProductImageName3"]);
                        p.CategoryID = Convert.ToInt32(reader["ProductCategoryID"]);
                        p.Quantity = Convert.ToInt32(reader["ProductQuantity"]);

                        products.Add(p);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return products;
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
                        p.CategoryID = Convert.ToInt32(reader["ProductCategoryID"]);
                        p.Quantity = Convert.ToInt32(reader["ProductQuantity"]);


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


        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetAllProducts, conn);
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
                        p.CategoryID = Convert.ToInt32(reader["ProductCategoryID"]);
                        p.Quantity = Convert.ToInt32(reader["ProductQuantity"]);


                        products.Add(p);
                    }
                }
            }
            catch (SqlException ex)
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
                    //First Image
                    if (String.IsNullOrEmpty(p.ImageName1))
                    {
                        cmd.Parameters.AddWithValue("@ProductImageName1", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ProductImageName1", p.ImageName1);
                    }
                    //Second Image
                    if (String.IsNullOrEmpty(p.ImageName2))
                    {
                        cmd.Parameters.AddWithValue("@ProductImageName2", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ProductImageName2", p.ImageName2);
                    }
                    //Third Image
                    if (String.IsNullOrEmpty(p.ImageName3))
                    {
                        cmd.Parameters.AddWithValue("@ProductImageName3", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ProductImageName3", p.ImageName3);
                    }
                    cmd.Parameters.AddWithValue("@ProductCategoryID", p.CategoryID);

                    cmd.Parameters.AddWithValue("@ProductQuantity", p.Quantity);

                    cmd.ExecuteNonQuery();
                    return;
                }
            }catch(SqlException ex)
            {
                throw;
            }
        }
          
        public int EditProduct(Product EditedProduct)
          {
            //Product newProduct = GetProduct(EditedProduct.Id);
            //newProduct.Name = EditedProduct.Name;
            //newProduct.Price = EditedProduct.Price;
            //newProduct.Description = EditedProduct.Description;
            //newProduct.ImageName1 = EditedProduct.ImageName1;
            //newProduct.CategoryID = EditedProduct.CategoryID;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_EditProduct, conn);

                    cmd.Parameters.AddWithValue("@ProductName", EditedProduct.Name);
                    cmd.Parameters.AddWithValue("@ProductPrice", EditedProduct.Price);
                    cmd.Parameters.AddWithValue("@ProductDescription", EditedProduct.Description);
                    //First Image
                    if (EditedProduct.ImageName1 == null)
                    {
                        cmd.Parameters.AddWithValue("@ProductImageName1", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ProductImageName1", EditedProduct.ImageName1);
                    }

                    //Second Image
                    if (EditedProduct.ImageName2 == null)
                    {
                        cmd.Parameters.AddWithValue("@ProductImageName2", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ProductImageName2", EditedProduct.ImageName2);
                    }

                    //Third Image
                    if (EditedProduct.ImageName3 == null)
                    {
                        cmd.Parameters.AddWithValue("@ProductImageName3", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ProductImageName3", EditedProduct.ImageName3);
                    }

                    //cmd.Parameters.AddWithValue("@ProductImageName1", newProduct.ImageName1);
                    cmd.Parameters.AddWithValue("@ProductCategoryID", EditedProduct.CategoryID);
                    cmd.Parameters.AddWithValue("@ProductID", EditedProduct.Id);
                    cmd.Parameters.AddWithValue("ProductQuantity", EditedProduct.Quantity);



                    //cmd.Parameters.AddWithValue("@ProductName", newProduct.Name);
                    //cmd.Parameters.AddWithValue("@ProductPrice", newProduct.Price);
                    //cmd.Parameters.AddWithValue("@ProductDescription", newProduct.Description);

                    //if (newProduct.ImageName1 == null)
                    //{
                    //    cmd.Parameters.AddWithValue("@ProductImageName1", DBNull.Value);
                    //}
                    //else
                    //{
                    //    cmd.Parameters.AddWithValue("@ProductImageName1", newProduct.ImageName1);
                    //}
                    ////cmd.Parameters.AddWithValue("@ProductImageName1", newProduct.ImageName1);
                    // cmd.Parameters.AddWithValue("@ProductCategoryID", newProduct.CategoryID);
                    //cmd.Parameters.AddWithValue("@ProductID", newProduct.Id);
                    cmd.ExecuteNonQuery();
                }
            }catch(SqlException ex)
            {
                throw ex;
            }
            //return newProduct.Id;
            return EditedProduct.Id;
        }

       
    }
}