using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeautyStore.Facade;
using BeautyStore.Models;

namespace BeautyStore.Areas.Admin.Controllers
{
    public class AdminBrandsController : Controller
    {
        private BrandFacade _brandFacade = new BrandFacade();

        // GET: Admin/AdminBrands
        public ActionResult Index()
        {
            return View(_brandFacade.GetAllBrands());
        }

        // GET: Admin/AdminBrands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = _brandFacade.GetBrand(id.Value);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // GET: Admin/AdminBrands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminBrands/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrandID,BrandName,BrandImage")] Brand brand, HttpPostedFileBase ImgBrand)
        {
            if (ModelState.IsValid)
            {
                _brandFacade.CreateBrand(brand, ImgBrand);
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        // GET: Admin/AdminBrands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = _brandFacade.GetBrand(id.Value);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: Admin/AdminBrands/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrandID,BrandName,BrandImage")] Brand brand, HttpPostedFileBase ImgBrand)
        {
            if (ModelState.IsValid)
            {
                _brandFacade.EditBrand(brand, ImgBrand);
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        // GET: Admin/AdminBrands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = _brandFacade.GetBrand(id.Value);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: Admin/AdminBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _brandFacade.DeleteBrand(id);
            return RedirectToAction("Index");
        }
    }
}
