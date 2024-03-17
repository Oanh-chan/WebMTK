using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeautyStore.Models;
using BeautyStore.State;

namespace BeautyStore.Areas.Admin.Controllers
{
    public class AdminOrdersController : Controller
    {
        private BeautyStoreEntities1 db = new BeautyStoreEntities1();

        // GET: Admin/AdminOrders
        // GET: Admin/AdminOrders

        private IOrderState orderState;

        public AdminOrdersController()
        {
            db = new BeautyStoreEntities1();
            orderState = new OrderState(db);
        }
        public ActionResult Index()
        {
            var orders = (from order in db.Orders orderby order.IdOrder descending select order).ToList();
            return View(orders.ToList());
        }

        // GET: Admin/AdminOrders/Details/5
        public ActionResult Details(int? id)
        {
            var listProdOrder = db.OrderDetails.Where(order => order.IdOrder == id).ToList();
            decimal finalPrice = 0;
            foreach (var item in listProdOrder)
            {
                finalPrice += (decimal)item.FinalPrice;
            }
            ViewBag.FinalPrice = finalPrice;
            ViewBag.Address = db.Orders.FirstOrDefault(o => o.IdOrder == id).Address;
            ViewBag.Date = db.Orders.FirstOrDefault(o => o.IdOrder == id).DateOrder;
            ViewBag.Id = db.Orders.FirstOrDefault(o => o.IdOrder == id).IdOrder;
            ViewBag.Status = db.Orders.FirstOrDefault(o => o.IdOrder == id).StatusOrder;

            ViewBag.CusInfor = db.Orders.FirstOrDefault(o => o.IdOrder == id);

            return View(listProdOrder);
        }

        public ActionResult Confirm(int id)
        {
            orderState.ProcessOrder(id);
            return RedirectToAction("Index");
        }



        public ActionResult CancelOrder(int id)
        {

            orderState.CancelOrder(id);
            return RedirectToAction("Index");
        }
    }

}
