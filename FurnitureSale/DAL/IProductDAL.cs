using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureSale.Models;

namespace FurnitureSale.DAL
{
    public interface IProductDAL
    {
        List<Product> GetLast20Products();
        void SaveNewProduct(Product p);
        Product GetProduct(int id);
        //int EditProduct(int id, Product productToEdit);
        int EditProduct(Product productRoEdit);
        List<Product> GetLivingRoomProducts();
        List<Product> GetBedRoomProducts();
        List<Product> GetDiningRoomProducts();
        List<Product> GetKitchenProducts();
        List<Product> GetBabiesKidsProducts();



    }
}

