﻿using OrderSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSmart.Services.ProductService
{
    public interface IProductService
    {

        public List<Product> GetAllProducts();
        public Product GetProductByID(int productId);
        public List<Product> GetProductsBySearch(string sName, double sMinPrice, double sMaxPrice);
        public Product UpdateStock(int productId, int amount);

    }
}