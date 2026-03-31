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
        Task<IEnumerable<Product>> GetUserFavoritesAsync(string userId);

        Task<bool> IsProductInFavoritesAsync(string userId, int productId);

        Task AddToFavoritesAsync(string userId, int productId);

        Task RemoveFromFavoritesAsync(string userId, int productId);
    }
}
