using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautyStore.Models
{
    public interface IFavoriteProductAdapter
    {
        void InsertFavoriteProduct(FavoriteProduct favoriteProd);
        void DeleteFavoriteProduct(FavoriteProduct favoriteProd);
    }
}