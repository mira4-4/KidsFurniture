using KidsFurniture.Infrastructure.Data;
using KidsFurniture.Infrastructure.Data.Entities;

using KidsFurnitureApp.Core.Contracts;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFurnitureApp.Core.Services
{
    public class FavoriteService : IFavoritesService
    {
        private readonly ApplicationDbContext _context;
        public FavoriteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddToFavoritesAsync(string userId, int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetUserFavoritesAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsProductInFavoritesAsync(string userId, int productId)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveFromFavoritesAsync(string userId, int productId)
        {
            var favorite = await _context.Favorites.FirstOrDefaultAsync(fv => fv.UserId== userId && fv.ProductId == productId);

            if (favorite == null)
            {
                _context.Favorites.Remove(favorite);
                await _context.SaveChangesAsync();
            }
        }

    }
}
