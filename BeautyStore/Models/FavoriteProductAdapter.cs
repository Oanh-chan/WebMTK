using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautyStore.Models
{
    public class FavoriteProductAdapter : IFavoriteAdapter
    {
        private readonly BeautyStoreEntities1 _db;

        public FavoriteProductAdapter()
        {
            _db = new BeautyStoreEntities1();
        }

        public void InsertFavoriteProduct(FavoriteProduct favoriteProd)
        {
            _db.FavoriteProducts.Add(favoriteProd);
            _db.SaveChanges();
        }

        public void DeleteFavoriteProduct(FavoriteProduct favoriteProd)
        {
            var prod = _db.FavoriteProducts.FirstOrDefault(p => p.ProductID == favoriteProd.ProductID && p.UserID == favoriteProd.UserID);
            if (prod != null)
            {
                _db.FavoriteProducts.Remove(prod);
                _db.SaveChanges();
            }
        }
    }
}