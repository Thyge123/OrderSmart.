﻿using OrderSmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSmart.Services.OrderService
{
    interface IOrderService
    {
        void AddOrder(Order order);
        List<Order> GetAllOrders();
        void UpdateOrder(Order.Status status, Order order);
        void DeleteOrder(Order order);

    }
}