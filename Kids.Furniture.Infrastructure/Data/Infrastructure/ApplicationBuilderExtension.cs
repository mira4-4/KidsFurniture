using KidsFurniture.Infrastructure.Data.Entities;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFurniture.Infrastructure.Data.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);

            var dataCategory = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedCategories(dataCategory);

            var dataBrand = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedBrands (dataBrand);


            return app;
        }
        private static void SeedCategories(ApplicationDbContext dataCategory)
        {
            if (dataCategory.Categories.Any())
            {
                return;
            }
            dataCategory.Categories.AddRange(new[]
            {
                new Category {CategoryName="Детски легла"},
                new Category {CategoryName="Бюра"},
                new Category {CategoryName="Маси"},
                new Category {CategoryName="Мека мебел"},
                new Category {CategoryName="Гардероби и Скринове"},
                new Category {CategoryName="Игра и Организация"},
                new Category {CategoryName="Модулни системи"},
                new Category {CategoryName="БИО почистване"},

            });
            dataCategory.SaveChanges();
        }
        private static void SeedBrands(ApplicationDbContext dataBrand)
        {
            if (dataBrand.Brands.Any())
            {
                return;
            }
            dataBrand.Brands.AddRange(new[]
            {
                new Brand { BrandName = "Videnov" },
                new Brand { BrandName = "Nachevi 90" },
                new Brand { BrandName = "Kambo Furniture" },
                new Brand { BrandName = "MIM BULGARIA" },
                new Brand { BrandName = "Mebeliss" },
                new Brand { BrandName = "Meblex" },

            });
            dataBrand.SaveChanges();
        }
        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Administrator", "Client" };

            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }

            }
        }
        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            {
                if (await userManager.FindByNameAsync("admin") == null)
                {
                    ApplicationUser user = new ApplicationUser();
                    user.FirstName = "admin";
                    user.LastName = "admin";
                    user.UserName = "admin";
                    user.Email = "admin@admin.com";
                    user.Address = "admin address";
                    user.PhoneNumber = "0444444444";

                    var result = await userManager.CreateAsync
                    (user, "Admin123456");

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Administrator").Wait();
                    }

                }
            }
        }
    }
}


