using SedraCoffe.Models;
using SedraCoffe.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SedraCoffe.Repositories
{
    public class OrderRepository
    {
        private SedraRestaurantDBEntities objSedraRestaurantDbEntities;
        public OrderRepository()
        {
            objSedraRestaurantDbEntities = new SedraRestaurantDBEntities();
        }
        public bool AddOrder(OrderViewModel objOrderViewModel)
        {
            Order objOrder = new Order();
            objOrder.CustomerId = objOrderViewModel.CustomerId;
            objOrder.FinalTotal = objOrderViewModel.FinalTotal;
            objOrder.OrderDate = DateTime.Now;
            objOrder.OrderNumber = String.Format("{0:ddmmmyyyyhhmmss}", DateTime.Now);
            objOrder.PaymentTypeId = objOrderViewModel.PaymentTypeId;
            objSedraRestaurantDbEntities.Orders.Add(objOrder);
            objSedraRestaurantDbEntities.SaveChanges();
            int OrderId = objOrder.OrderId;

            foreach (var item in objOrderViewModel.ListOfOrderDetailViewModel)
            {
                OrderDetail objOrderDetail = new OrderDetail();
                objOrderDetail.OrderId = OrderId;
                objOrderDetail.Discount = item.Discount;
                objOrderDetail.ItemId = item.ItemId;
                objOrderDetail.Total = item.Total;
                objOrderDetail.UnitPrice = item.UnitPrice;
                objOrderDetail.Quantity = item.Quantity;
                
                objSedraRestaurantDbEntities.OrderDetails.Add(objOrderDetail);
                objSedraRestaurantDbEntities.SaveChanges();

                Transaction objTransaction = new Transaction();
                objTransaction.ItemId = item.ItemId;
                objTransaction.Quantity = (-1)*item.Quantity;
                objTransaction.TransactionDate = DateTime.Now;
                objTransaction.TypeId = 2;

                objSedraRestaurantDbEntities.Transactions.Add(objTransaction);
                objSedraRestaurantDbEntities.SaveChanges();
            }

            return true;
        }
    }
}