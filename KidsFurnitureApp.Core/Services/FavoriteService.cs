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

        public bool AddToFavorites(string userId, int productId)
        {
            var userProduct = new Favorites
            {
                UserId = userId,
                ProductId = productId
            };
             _context.Favorites.Add(userProduct);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<Product> GetUserFavorites(string userId)
        {
            return _context.Favorites
                .Where(fv => fv.UserId == userId)
                .Select(fv => fv.Product).ToList();
        }

        public bool IsProductInFavorites(string userId, int productId)
        {
            return _context.Favorites
                .Any(fv => fv.UserId == userId && fv.ProductId == productId);
        }

        public bool RemoveFromFavorites(string userId, int productId)
        {
            var favorite = _context.Favorites.FirstOrDefault(fv => fv.UserId== userId && fv.ProductId == productId);

            if (favorite != null)
            {
                _context.Favorites.Remove(favorite);
                
            }
            return _context.SaveChanges() != 0;

        }

    }
}
