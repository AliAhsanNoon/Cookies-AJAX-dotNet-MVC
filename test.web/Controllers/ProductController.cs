using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.web.Models;

namespace test.web.Controllers
{
    public class ProductController : Controller
    {
        samsungEntities context = new samsungEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable()
        {
            var pro = context.Products.ToList();
            return PartialView(pro);
        }

        [HttpGet]
        public ActionResult GetData()
        {
            var pro = context.Products.ToList();
            return Json(new { data = pro }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            using (context)
            {
                context.Products.Add(product);
                context.SaveChanges();
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("GetData");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (context)
            {
                var epro = context.Products.ToList().SingleOrDefault(p => p.ID == id);
                return PartialView(epro);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            using (context)
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (context)
            {
                var del = context.Products.Where(x => x.ID == id).Single();
                context.Products.Remove(del);
                //context.Entry(del).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
            return Json(new { success = true}, JsonRequestBehavior.AllowGet);
        }
    }
}