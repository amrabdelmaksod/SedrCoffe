using SedraCoffe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SedraCoffe.Repositories
{
    public class ItemRepository
    {
        private SedraRestaurantDBEntities objSedraDbEntities;
        public ItemRepository()
        {
            objSedraDbEntities = new SedraRestaurantDBEntities();

        }
        public IEnumerable<SelectListItem> GetAllItems()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objSedraDbEntities.Items
                                  select new SelectListItem()
                                  {
                                      Text = obj.ItemName,
                                      Value = obj.ItemId.ToString(),
                                      Selected = false

                                  }).ToList();
            return objSelectListItems;
        }
    }
}