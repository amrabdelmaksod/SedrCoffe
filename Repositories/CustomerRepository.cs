using SedraCoffe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SedraCoffe.Repositories
{
    public class CustomerRepository
    {
        private SedraRestaurantDBEntities objSedraRestaurantDbEntities;
        public CustomerRepository()
        {
            objSedraRestaurantDbEntities = new SedraRestaurantDBEntities();
        }
        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objSedraRestaurantDbEntities.Customers
                                  select new SelectListItem()
                                  {
                                      Text = obj.CustomerName,
                                      Value = obj.CustomerId.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;
        }
    }
}