using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureSale.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Weight { get; set; }
        public int Quantity { get; set; }
        public string Dimension { get; set; }
        public int Msrp { get; set; }
        public string Description { get; set; }
        public string ImageName1 { get; set; }
        public string ImageName2 { get; set; }
        public string ImageName3 { get; set; }
        public int CategoryID { get; set; }

    }
}