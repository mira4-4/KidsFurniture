using KidsFurniture.Infrastructure.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFurnitureApp.Core.Contracts
{
    
    public interface IFavoritesService
    {
        IEnumerable<Product> GetUserFavorites(string userId);

        bool IsProductInFavorites(string userId, int productId);

        bool AddToFavorites(string userId, int productId);

        bool RemoveFromFavorites(string userId, int productId);
    }
}
