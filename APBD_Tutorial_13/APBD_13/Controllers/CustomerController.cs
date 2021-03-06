﻿using APBD_13.DTO;
using APBD_13.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace APBD_13.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext _customerDbContext;
        public CustomerController(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
        [HttpGet("order/{cname}")]
        public IActionResult GetOrders(String cname) 
        {
            GetOrderRequest orderRequest = new GetOrderRequest();
            var name = _customerDbContext.Customers.Where(d => d.Name.Equals(cname)).ToList().FirstOrDefault();
            /*string customerName, GetOrderRequest orderRequest*/

            if (name == null)
            {
                return BadRequest("Such a person does not exist");
            }
            else if (cname == " ")
            {
                var order_list = new List<GetOrderRequest>();
                var order = (from item in _customerDbContext.Orders
                             select item).ToList();
                foreach(var item in order)
                {
                    var conf_order = _customerDbContext.Confectionaries_Order.Where(e => e.IdOrder.Equals(item.IdOrder)).ToList().FirstOrDefault();
                    var conf = _customerDbContext.Confectionaries.Where(e => e.IdConfectionary.Equals(conf_order.IdConfection)).ToList().FirstOrDefault();

                    orderRequest.IdOrder = item.IdOrder;
                    orderRequest.DateAccepted = item.DateAccepted;
                    orderRequest.DateFinished = item.DateFinished;
                    orderRequest.QuantityOfConfectionary = conf_order.Quantity;
                    orderRequest.IdConfectionary = conf.IdConfectionary;
                    order_list.Add(orderRequest);
                }
                
               
                return Ok(order_list);
            }
            else
            {

                var order = _customerDbContext.Orders.Where(d => d.IdClient.Equals(name.IdClient)).ToList().FirstOrDefault();
                var conf_order = _customerDbContext.Confectionaries_Order.Where(e => e.IdOrder.Equals(order.IdOrder)).ToList().FirstOrDefault();
                var conf = _customerDbContext.Confectionaries.Where(e => e.IdConfectionary.Equals(conf_order.IdConfection)).ToList().FirstOrDefault();

                orderRequest.IdOrder = order.IdOrder;
                orderRequest.DateAccepted = order.DateAccepted;
                orderRequest.DateFinished = order.DateFinished;
                orderRequest.QuantityOfConfectionary = conf_order.Quantity;
                orderRequest.IdConfectionary = conf.IdConfectionary;

                return Ok(orderRequest);

            }
            
        }
        [HttpPost("clients/{id}")]
        public IActionResult AddOrder(AddOrderRequest addOrderRequest, int id)
        {
            Order order = new Order();
            Confectionary newConfectionary = new Confectionary();
            Confectionary_Order newconfectionary_Order = new Confectionary_Order();
            newconfectionary_Order.IdConfection = newConfectionary.IdConfectionary;
            newconfectionary_Order.IdOrder = order.IdOrder;



            order.DateAccepted = addOrderRequest.DateAccepted;
            order.Notes = addOrderRequest.Notes;
            order.IdClient = id;
            order.IdEmployee = id;

            CustomConfectionary confectionary = addOrderRequest.Confectionery.FirstOrDefault();

            string product = confectionary.Name;
            int quantity = confectionary.Quantity;
            newconfectionary_Order.Quantity = quantity;
            var listItems = (from row in _customerDbContext.Confectionaries
                             where row.Name == product
                             select row.Name).ToList().FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(listItems))
            {
                newConfectionary.Name = confectionary.Name;
                newconfectionary_Order.Notes = confectionary.Notes;

                _customerDbContext.Add(order);
                _customerDbContext.Add(newConfectionary);
                _customerDbContext.Add(newconfectionary_Order);
                _customerDbContext.SaveChanges();

                return Ok("Order added");
            }
            else
            {
                return BadRequest("Product mentioned does not exist");
            }



        }
    }
}
