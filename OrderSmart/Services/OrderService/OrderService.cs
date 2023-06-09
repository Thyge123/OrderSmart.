﻿using OrderSmart.Models;
using OrderSmart.Services.JSONService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
* 
* Af Mads
*
*/

namespace OrderSmart.Services.OrderService
{
    public class OrderService : IOrderService
    {

        private JSONFileService _jsonFileService { get; set; }
        private List<Order> Orders { get; set; }

        public OrderService(JSONFileService jsonFileService)
        {

            _jsonFileService = jsonFileService;
            Orders = _jsonFileService.GetOrders();

        }

        /// <summary>
        /// Method that adds an Order to the list of orders.
        /// </summary>
        /// <param name="order">Order to be added.</param>
        public void AddOrder(Order order)
        {
            Orders.Add(order);
            _jsonFileService.SaveOrderJSON(order);
        }

        /// <summary>
        /// Method that generates an ID for an Order, to ensure each Order has a unique ID.
        /// No Order can have the ID of 0, if so, it's regarded as not having an ID.
        /// </summary>
        /// <returns></returns>
        public int GenerateID()
        {

            int ID = 1;
            bool foundID = false;

            while(!foundID)
            {

                if(Orders.Count == 0)
                {
                    foundID = true;
                }

                foreach(Order o in Orders)
                {
                    if(o.ID != ID)
                    {

                        foundID = true;

                    } else
                    {
                        ID += 1;
                    }
                }

            }

            return ID;

        }

        /// <summary>
        /// Method that returns all objects of type Order from the Orders-list.
        /// </summary>
        /// <returns>List of Orders</returns>
        public List<Order> GetAllOrders()
        {
            return Orders;
        }

        /// <summary>
        /// Method that takes a given id, and tries to match to an existing order in the orders list.
        /// </summary>
        /// <param name="id">Integer value of the order to find.</param>
        /// <returns>Order object, or null if none found.</returns>
        public Order GetOrderByID(int id)
        {

            foreach(Order o in Orders)
            {
                if (o.ID == id) return o;
            }

            return null;

        }

        /// <summary>
        /// Method that updates the status of the order.
        /// </summary>
        /// <param name="status">The new status of the order.</param>
        /// <param name="order">The order to update.</param>
        public void UpdateOrder(Order.Status status, Order order)
        {

            order.OrderStatus = status;
            _jsonFileService.SaveOrderJSON(order);

        }

        /// <summary>
        /// Method that deletes an order from the list.
        /// </summary>
        /// <param name="order">Order to be removed.</param>
        public void DeleteOrder(Order order)
        {
            Orders.Remove(order);
        }

        /// <summary>
        /// Method that gets all orders given by the status.
        /// </summary>
        /// <param name="status">Status to search for.</param>
        /// <returns>Orders retrieved.</returns>
        public IEnumerable<Order> GetOrdersByStatus(Order.Status status)
        {

            List<Order> orders = new List<Order>();

            foreach(Order o in Orders)
            {
                if (o.OrderStatus == status) orders.Add(o);
            }

            return orders;

        }

    }
}
