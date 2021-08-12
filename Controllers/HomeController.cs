using SedraCoffe.Models;
using SedraCoffe.Repositories;
using SedraCoffe.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SedraCoffe.Controllers
{
    public class HomeController : Controller
    {
        private SedraRestaurantDBEntities objSedraRestaurantDbEntities;

        public HomeController()
        {
            objSedraRestaurantDbEntities = new SedraRestaurantDBEntities();

        }
        // GET: Home
        public ActionResult Index()
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            ItemRepository objItemRepository = new ItemRepository();
            PaymentTypeRepository objpaymentTypeRepository = new PaymentTypeRepository();


            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (objCustomerRepository.GetAllCustomers(),objItemRepository.GetAllItems(), objpaymentTypeRepository.GetAllPaymentTypes());
            return View(objMultipleModels);
        }

        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal unitPrice = objSedraRestaurantDbEntities.Items.Single(model => model.ItemId == itemId).ItemPrice;
            return Json(unitPrice, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Index(OrderViewModel objOrderViewModel)
        {
            OrderRepository objOrderRepository = new OrderRepository();
            objOrderRepository.AddOrder(objOrderViewModel);
            return Json(data:"Your Order has been Successfully Placed.", JsonRequestBehavior.AllowGet);
        }

       
    }
}