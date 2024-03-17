using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeautyStore.Models;
using BeautyStore.Factory;

namespace BeautyStore.Controllers
{
    public class FavoriteProductController : Controller
    {
        private readonly BeautyStoreEntities1 _db;
        private readonly IFavoriteAdapter _favoriteProductAdapter;

        public FavoriteProductController()
        {
            _db = new BeautyStoreEntities1();
            _favoriteProductAdapter = new FavoriteProductAdapter();
        }

        // GET: FavoriteProduct
        public ActionResult FavoriteList(int? id)
        {
            if (id == null)
            {
                // Xử lý khi id là null
                return RedirectToAction("Error", "Home");
            }

            var product = _db.FavoriteProducts.Where(n => n.UserID == id).ToList();

            List<Product> productList = new List<Product>();

            foreach (var item in product)
            {
                Product prod = ProductFactory.CreateProduct((int)item.ProductID);
                productList.Add(prod);

            }
            ViewBag.ProductInfor = productList;
            return View(product);
        }

        [HttpPost]
        public ActionResult InsertListFavorite(FavoriteProduct favoriteProd)
        {
            if (ModelState.IsValid)
            {
                var productAvail = _db.FavoriteProducts.FirstOrDefault(p => p.ProductID == favoriteProd.ProductID && p.UserID == favoriteProd.UserID);
                if (productAvail != null)
                    return RedirectToAction("Index/" + favoriteProd.ProductID, "Details");
                else
                {
                    _favoriteProductAdapter.InsertFavoriteProduct(favoriteProd);
                    return RedirectToAction("FavoriteList/" + favoriteProd.UserID, "FavoriteProduct");
                }
            }
            return View("Index/" + favoriteProd.ProductID, "Details");
        }

        public ActionResult DeleteProduct(FavoriteProduct favoriteProd)
        {
            if (ModelState.IsValid)
            {
                _favoriteProductAdapter.DeleteFavoriteProduct(favoriteProd);
            }
            return RedirectToAction("FavoriteList/" + favoriteProd.UserID, "FavoriteProduct");
        }
    }
}