using SedraCoffe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SedraCoffe.Repositories
{
    public class PaymentTypeRepository
    {
        private SedraRestaurantDBEntities objSedraDbEntities;
        public PaymentTypeRepository()
        {
            objSedraDbEntities = new SedraRestaurantDBEntities();

        }
        public IEnumerable<SelectListItem> GetAllPaymentTypes()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objSedraDbEntities.PaymentTypes
                                  select new SelectListItem()
                                  {
                                      Text = obj.PaymentTypeName,
                                      Value = obj.PaymentTypeId.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;
        }
    }
}