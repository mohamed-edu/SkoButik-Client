using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SkoButik_Client.Models;
using System.IO;

namespace SkoButik_Client.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                // Check if the Users table exists, if not, create the database
                if (!context.Users.Any())
                {
                    // Add initial users or do nothing if you want to register users manually
                }


                //Actors
                if (!context.Brands.Any())
                {
                    context.Brands.AddRange(new List<Brand>()
                    {
                        new Brand()
                        {
                            BrandName = "Nike"

                        },
                        new Brand()
                        {
                            BrandName = "Adidas"

                        },
                      new Brand()
                        {
                            BrandName = "Puma"

                        },
                      new Brand()
                        {
                            BrandName = "Vans"

                        }
                    });
                    context.SaveChanges();
                }
                //Produvers
                if (!context.Sizes.Any())
                {
                    context.Sizes.AddRange(new List<Size>()
                    {
                        new Size()
                        {
                            SizeName = "EU Men's Size 40"

                        },
                        new Size()
                        {
                            SizeName = "EU Men's Size 41"

                        },
                        new Size()
                        {
                            SizeName = "EU Men's Size 42"

                        },
                        new Size()
                        {
                            SizeName = "EU Men's Size 43"

                        },
                        new Size()
                        {
                            SizeName = "EU Wmn's Size 36"

                        },
                        new Size()
                        {
                            SizeName = "EU Wmn's Size 37"

                        },
                        new Size()
                        {
                            SizeName = "EU Wmn's Size 38"

                        },
                        new Size()
                        {
                            SizeName = "EU Wmn's Size 39"

                        }
                    });
                    context.SaveChanges();



                }
                //Products
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            ProductName = "Nike Air Force 1 Low",
                            Description = "Lorem ipsum dolor sit amet, consectetur",
                            FkBrandId = 1,
                            FkSizeId = 1,
                            ImageUrl = "/images/Nike_airforce_low_BlackRed.jpg",
                            Price = 1500.00M
                        },
                        new Product()
                        {
                            ProductName = "Adidas Orginal Superstars",
                            Description = "Lorem ipsum dolor sit amet, consectetu",
                            FkBrandId = 2,
                            FkSizeId = 1,
                            ImageUrl = "/images/Adidas_OrignialSuperstar.jpg",
                            Price = 999.00M

                        },
                        new Product()
                        {
                            ProductName = "Puma Xray",
                            Description = "Lorem ipsum dolor sit amet, consectetu",
                            FkBrandId = 3,
                            FkSizeId = 1,
                            ImageUrl = "/images/Puma_Xray.jpg",
                            Price = 950.00M
                        },
                        new Product()
                        {
                            ProductName = "Vans OldSkool",
                            Description = "Lorem ipsum dolor sit amet, consectetur",
                            FkBrandId = 4,
                            FkSizeId = 1,
                            ImageUrl = "/images/Vans_OldSkool.jpg",
                            Price = 1200.00M
                        }
                    });  
                    context.SaveChanges();
                }
            }
        }
    }
}

