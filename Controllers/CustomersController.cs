using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AngularJS_CRUD.Models;

namespace AngularJS_CRUD.Controllers
{
    public class CustomersController : ApiController
    {
        [Route("api/AjaxAPI/GetCustomers")]
        [HttpPost]
        public List<Customer> GetCustomers()
        {
            WebAPIEntities1 entities = new WebAPIEntities1();
            return entities.Customers.ToList();
        }

        [Route("api/AjaxAPI/InsertCustomer")]
        [HttpPost]
        public Customer InsertCustomer(Customer customer)
        {
            using (WebAPIEntities1 entities = new WebAPIEntities1())
            {
                entities.Customers.Add(customer);
                entities.SaveChanges();
            }

            return customer;
        }

        [Route("api/AjaxAPI/UpdateCustomer")]
        [HttpPost]
        public bool UpdateCustomer(Customer customer)
        {
            using (WebAPIEntities1 entities = new WebAPIEntities1())
            {
                Customer updatedCustomer = (from c in entities.Customers
                                            where c.CustomerId == customer.CustomerId
                                            select c).FirstOrDefault();
                updatedCustomer.Name = customer.Name;
                updatedCustomer.Country = customer.Country;
                entities.SaveChanges();
            }

            return true;
        }

        [Route("api/AjaxAPI/DeleteCustomer")]
        [HttpPost]
        public void DeleteCustomer(Customer _customer)
        {
            using (WebAPIEntities1 entities = new WebAPIEntities1())
            {
                Customer customer = (from c in entities.Customers
                                     where c.CustomerId == _customer.CustomerId
                                     select c).FirstOrDefault();
                entities.Customers.Remove(customer);
                entities.SaveChanges();
            }
        }
    }
}