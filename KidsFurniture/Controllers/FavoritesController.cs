using KidsFurniture.Models.Product;

using KidsFurnitureApp.Core.Contracts;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

using System.Security.Claims;

namespace KidsFurniture.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IFavoritesService favoritesService;

        public FavoritesController(IFavoritesService favoritesService)
        {
            this.favoritesService = favoritesService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            List<ProductIndexVM> products = (favoritesService.GetUserFavorites(userId))
                .Select(products => new ProductIndexVM
                {
                    Id = products.Id,
                    ProductName = products.ProductName,
                    BrandId = products.BrandId,
                    BrandName = products.Brand.BrandName,
                    CategoryId = products.CategoryId,
                    CategoryName = products.Category.CategoryName,
                    Picture = products.Picture,
                    Description = products.Description,
                    Quantity = products.Quantity,
                    Price = products.Price,
                    Discount = products.Discount,
                }).ToList();
            return View(products);
        }
        [HttpPost]

        public ActionResult Add(int productId)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            bool isInFavorites = favoritesService.IsProductInFavorites(userId, productId);
            if (!isInFavorites)
            {
                favoritesService.AddToFavorites(userId, productId);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]

        public IActionResult Remove(int productId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);


            bool isInFavorites = favoritesService.IsProductInFavorites(userId, productId);
            if (isInFavorites)
            {
                favoritesService.RemoveFromFavorites(userId, productId);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
