using BeautyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautyStore.Factory
{
    public static class ProductFactory
    {
        public static Product CreateProduct(int productId)
        {
            // Lấy thông tin sản phẩm từ cơ sở dữ liệu dựa trên ProductID
            using (BeautyStoreEntities1 db = new BeautyStoreEntities1())
            {
                FavoriteProduct favoriteProd = db.FavoriteProducts.FirstOrDefault(p => p.ProductID == productId);
                Product prod = db.Products.FirstOrDefault(p => p.ProductID == favoriteProd.ProductID);
                return prod;
            }
        }
    }

}