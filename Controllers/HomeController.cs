using MVC_Empty.Models;
using MVC_Empty.Models.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;
using System.Web.UI.WebControls.WebParts;

namespace MVC_Empty.Views
{
    public class HomeController : Controller
    {
        // GET: Home
        NorthwindEntities db=new NorthwindEntities();
        public ActionResult Index()
        {
            var model = db.Orders.ToList();
            return View(model);
        }

        [Route("Home/GetId")]
        public ActionResult GetId()
        {
            return Content("Hahaha");
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Insert(Order ord)
        {
            if(ord.OrderID==0)
            {
                db.Orders.Add(ord);
            }
            else
            {
                var updateData = db.Orders.Find(ord.OrderID);
                if(updateData==null)
                {
                    return HttpNotFound();
                }
                updateData.ShipName=ord.ShipName;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Update(int id)
        {
            var model = db.Orders.Find(id);
            if(model==null)
            {
                return HttpNotFound();
            }
            return View("Insert", model) ;
        }
        public ActionResult Delete(int id)
        {
            var deleteOrder=db.Orders.Find(id);
            if(deleteOrder==null)
            {
                return HttpNotFound();
            }
            db.Orders.Remove(deleteOrder);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}