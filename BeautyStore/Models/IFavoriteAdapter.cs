using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautyStore.Models
{
    public interface IFavoriteAdapter
    {
        void InsertFavoriteProduct(FavoriteProduct favoriteProd);
        void DeleteFavoriteProduct(FavoriteProduct favoriteProd);
    }
}