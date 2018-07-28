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
    public class ProductSqlDAL:  IProductDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["FurnitureSaleDB"].ConnectionString;
        const string SQL_GetTop20Products = "SELECT TOP 10 products.* from products";
        const string SQL_GetAllProducts = "SELECT products.* from products";
        const string SQL_InsertNewProduct = "INSERT INTO products VALUES(@name, @price, @description, @image_name1, @image_name2, @image_name3, @categoryId, @quantity, @active_listing)";
        const string SQL_GetProductById = "SELECT products.*, categories.* FROM products JOIN categories ON products.categoryId = categories.Id WHERE products.Id =@id";
        const string SQL_EditProduct = "UPDATE products set name = @name, price = @price, description = @description, image_name1 = @image_name1, categoryId = @categoryId, " +
            "quantity = @quantity, active_listing = @active_listing WHERE Id = @Id";
        const string SQL_DeleteProduct = "DELETE from products WHERE Id = @Id";
        const string SQL_GetLivingRoomProducts = "SELECT products.* FROM products WHERE products.categoryId = 1";
        const string SQL_GetBedRoomProducts = "SELECT products.* FROM products WHERE products.categoryId = 2";
        const string SQL_GetDiningRoomProducts = "SELECT products.* FROM products WHERE products.categoryId = 3";
        const string SQL_KitchenProducts = "SELECT products.* FROM products WHERE products.categoryId = 4";
        const string SQL_BabiesKidsProducts = "SELECT products.* FROM products WHERE products.categoryId = 5";
        const string SQL_OfficeAndOrganizerProducts = "SELECT products.* FROM products WHERE products.categoryId = 6";




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
                        p.Id = Convert.ToInt32(reader["Id"]);
                        p.Name = Convert.ToString(reader["name"]);
                        p.Price = Convert.ToDecimal(reader["price"]);
                        p.Description = Convert.ToString(reader["description"]);
                        p.ImageName1 = Convert.ToString(reader["image_name1"]);
                        p.ImageName2 = Convert.ToString(reader["image_name2"]);
                        p.ImageName3 = Convert.ToString(reader["image_name3"]);
                        p.CategoryID = Convert.ToInt32(reader["categoryId"]);
                        p.Quantity = Convert.ToInt32(reader["quantity"]);
                        p.ActiveListing = Convert.ToString(reader["active_listing"]);
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
                        p.Id = Convert.ToInt32(reader["Id"]);
                        p.Name = Convert.ToString(reader["name"]);
                        p.Price = Convert.ToDecimal(reader["price"]);
                        p.Description = Convert.ToString(reader["description"]);
                        p.ImageName1 = Convert.ToString(reader["image_name1"]);
                        p.ImageName2 = Convert.ToString(reader["image_name2"]);
                        p.ImageName3 = Convert.ToString(reader["image_name3"]);
                        p.CategoryID = Convert.ToInt32(reader["categoryId"]);
                        p.Quantity = Convert.ToInt32(reader["quantity"]);
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
                        p.Id = Convert.ToInt32(reader["Id"]);
                        p.Name = Convert.ToString(reader["name"]);
                        p.Price = Convert.ToDecimal(reader["price"]);
                        p.Description = Convert.ToString(reader["description"]);
                        p.ImageName1 = Convert.ToString(reader["image_name1"]);
                        p.ImageName2 = Convert.ToString(reader["image_name2"]);
                        p.ImageName3 = Convert.ToString(reader["image_name3"]);
                        p.CategoryID = Convert.ToInt32(reader["categoryId"]);
                        p.Quantity = Convert.ToInt32(reader["quantity"]);
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
                        p.Id = Convert.ToInt32(reader["Id"]);
                        p.Name = Convert.ToString(reader["name"]);
                        p.Price = Convert.ToDecimal(reader["price"]);
                        p.Description = Convert.ToString(reader["description"]);
                        p.ImageName1 = Convert.ToString(reader["image_name1"]);
                        p.ImageName2 = Convert.ToString(reader["image_name2"]);
                        p.ImageName3 = Convert.ToString(reader["image_name3"]);
                        p.CategoryID = Convert.ToInt32(reader["categoryId"]);
                        p.Quantity = Convert.ToInt32(reader["quantity"]);
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
                        p.Id = Convert.ToInt32(reader["Id"]);
                        p.Name = Convert.ToString(reader["name"]);
                        p.Price = Convert.ToDecimal(reader["price"]);
                        p.Description = Convert.ToString(reader["description"]);
                        p.ImageName1 = Convert.ToString(reader["image_name1"]);
                        p.ImageName2 = Convert.ToString(reader["image_name2"]);
                        p.ImageName3 = Convert.ToString(reader["image_name3"]);
                        p.CategoryID = Convert.ToInt32(reader["categoryId"]);
                        p.Quantity = Convert.ToInt32(reader["quantity"]);
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
                        p.Id = Convert.ToInt32(reader["Id"]);
                        p.Name = Convert.ToString(reader["name"]);
                        p.Price = Convert.ToDecimal(reader["price"]);
                        p.Description = Convert.ToString(reader["description"]);
                        p.ImageName1 = Convert.ToString(reader["image_name1"]);
                        p.ImageName2 = Convert.ToString(reader["image_name2"]);
                        p.ImageName3 = Convert.ToString(reader["image_name3"]);
                        p.CategoryID = Convert.ToInt32(reader["categoryId"]);
                        p.Quantity = Convert.ToInt32(reader["quantity"]);
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

        public List<Product> GetOfficeAndOrganizerProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_OfficeAndOrganizerProducts, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Product p = new Product();
                        p.Id = Convert.ToInt32(reader["Id"]);
                        p.Name = Convert.ToString(reader["name"]);
                        p.Price = Convert.ToDecimal(reader["price"]);
                        p.Description = Convert.ToString(reader["description"]);
                        p.ImageName1 = Convert.ToString(reader["image_name1"]);
                        p.ImageName2 = Convert.ToString(reader["image_name2"]);
                        p.ImageName3 = Convert.ToString(reader["image_name3"]);
                        p.CategoryID = Convert.ToInt32(reader["categoryId"]);
                        p.Quantity = Convert.ToInt32(reader["quantity"]);
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
                        p.Id = Convert.ToInt32(reader["Id"]);
                        p.Name = Convert.ToString(reader["name"]);
                        p.Price = Convert.ToDecimal(reader["price"]);
                        //p.Weight = Convert.ToSingle(reader["ProductWeight"]);
                        //p.Quantity = Convert.ToInt32(reader["ProductQuantity"]);
                        //p.Dimension = Convert.ToString(reader["ProductDimension"]);
                        //p.Msrp = Convert.ToInt32(reader["ProductMsrp"]);
                        p.Description = Convert.ToString(reader["description"]);
                        p.ImageName1 = Convert.ToString(reader["image_name1"]);
                        //p.ImageName2 = Convert.ToString(reader["ProductImage2"]);
                        //p.ImageName3 = Convert.ToString(reader["ProductImage3"]);
                        p.CategoryID = Convert.ToInt32(reader["categoryId"]);
                        p.Quantity = Convert.ToInt32(reader["quantity"]);
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
                        p.Id = Convert.ToInt32(reader["Id"]);
                        p.Name = Convert.ToString(reader["name"]);
                        p.Price = Convert.ToDecimal(reader["price"]);
                        //p.Weight = Convert.ToSingle(reader["ProductWeight"]);
                        //p.Quantity = Convert.ToInt32(reader["ProductQuantity"]);
                        //p.Dimension = Convert.ToString(reader["ProductDimension"]);
                        //p.Msrp = Convert.ToInt32(reader["ProductMsrp"]);
                        p.Description = Convert.ToString(reader["description"]);
                        p.ImageName1 = Convert.ToString(reader["image_name1"]);
                        //p.ImageName2 = Convert.ToString(reader["ProductImage2"]);
                        //p.ImageName3 = Convert.ToString(reader["ProductImage3"]);
                        p.CategoryID = Convert.ToInt32(reader["categoryId"]);
                        p.Quantity = Convert.ToInt32(reader["quantity"]);
                        p.ActiveListing = Convert.ToString(reader["active_listing"]);
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
                    cmd.Parameters.AddWithValue("@name", p.Name);
                    cmd.Parameters.AddWithValue("@price", p.Price);
                    cmd.Parameters.AddWithValue("@description", p.Description);
                    //First Image
                    if (String.IsNullOrEmpty(p.ImageName1))
                    {
                        cmd.Parameters.AddWithValue("@image_name1", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@image_name1", p.ImageName1);
                    }
                    //Second Image
                    if (String.IsNullOrEmpty(p.ImageName2))
                    {
                        cmd.Parameters.AddWithValue("@image_name2", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@image_name2", p.ImageName2);
                    }
                    //Third Image
                    if (String.IsNullOrEmpty(p.ImageName3))
                    {
                        cmd.Parameters.AddWithValue("@image_name3", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@image_name3", p.ImageName3);
                    }
                    cmd.Parameters.AddWithValue("@categoryId", p.CategoryID);

                    cmd.Parameters.AddWithValue("@quantity", p.Quantity);

                    cmd.Parameters.AddWithValue("@active_listing", p.ActiveListing);

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

                    cmd.Parameters.AddWithValue("@name", EditedProduct.Name);
                    cmd.Parameters.AddWithValue("@price", EditedProduct.Price);
                    cmd.Parameters.AddWithValue("@description", EditedProduct.Description);
                    //First Image
                    if (EditedProduct.ImageName1 == null)
                    {
                        cmd.Parameters.AddWithValue("@image_name1", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@image_name1", EditedProduct.ImageName1);
                    }

                    //Second Image
                    if (EditedProduct.ImageName2 == null)
                    {
                        cmd.Parameters.AddWithValue("@image_name2", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@image_name2", EditedProduct.ImageName2);
                    }

                    //Third Image
                    if (EditedProduct.ImageName3 == null)
                    {
                        cmd.Parameters.AddWithValue("@image_name3", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@image_name3", EditedProduct.ImageName3);
                    }  
                    cmd.Parameters.AddWithValue("@categoryId", EditedProduct.CategoryID);
                    cmd.Parameters.AddWithValue("@Id", EditedProduct.Id);
                    cmd.Parameters.AddWithValue("@quantity", EditedProduct.Quantity);
                    cmd.Parameters.AddWithValue("@active_listing", EditedProduct.ActiveListing);
                    cmd.ExecuteNonQuery();
                }
            }catch(SqlException ex)
            {
                throw ex;
            }
            return EditedProduct.Id;
        }

        public void DeleteConfirm(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_DeleteProduct, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();                   
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}