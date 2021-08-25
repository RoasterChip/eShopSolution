using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() 
               {
                   Key = "HomeTitle", 
                   Value = "This is the home page of eShopSolution" 
               },
               new AppConfig()
               {
                   Key = "HomeKeyword", 
                   Value = "This is the keyword of eShopSolution" 
               },
               new AppConfig(){
                   Key = "HomeDescription", 
                   Value = "This is the description of eShopSolution" 
               }
            );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true},
                new Language() { Id = "en-US", Name = "English", IsDefault = false }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active
                },
                new Category()
                {
                    Id = 2,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 2,
                    Status = Status.Active
                }
            );

            modelBuilder.Entity<CategoryTranslation>().HasData(
                 new CategoryTranslation()
                 {
                     Id = 1,
                     CategoryId = 1,
                     Name = "Cà phê đặc sản",
                     LanguageId = "vi-VN",
                     SeoAlias = "ca-phe-dac-san",
                     SeoDescription = "Cà phê Arabica trên 80 điểm SCA",
                     SeoTitle = "Cà phê Arabica trên 80 điểm SCA"
                 },
                new CategoryTranslation()
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Specialty Coffee",
                    LanguageId = "en-US",
                    SeoAlias = "specialty-coffee",
                    SeoDescription = "Arabica coffee with SCA score above 80 points",
                    SeoTitle = "Arabica coffee with SCA score above 80 points"
                },
                new CategoryTranslation()
                {
                    Id = 3,
                    CategoryId = 2,
                    Name = "Cà phê thương mại",
                    LanguageId = "vi-VN",
                    SeoAlias = "ca-phe-thuong-mai",
                    SeoDescription = "Cà phê Arabica dưới 80 điểm SCA",
                    SeoTitle = "Cà phê Arabica dưới 80 điểm SCA"
                },
                new CategoryTranslation()
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "Commercial Coffee",
                    LanguageId = "en-US",
                    SeoAlias = "commercial-coffee",
                    SeoDescription = "Arabica coffee with SCA score below 80 points",
                    SeoTitle = "Arabica coffee with SCA score below 80 points"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product() 
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 300000,
                    Price = 400000,
                    Stock = 0,
                    ViewCount = 0
                });

            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     Name = "Cà phê đặc sản",
                     LanguageId = "vi-VN",
                     SeoAlias = "ca-phe-dac-san",
                     SeoDescription = "Cà phê Arabica trên 80 điểm SCA",
                     SeoTitle = "Cà phê Arabica trên 80 điểm SCA",
                     Details = "Mô tả sản phẩm",
                     Description = ""
                 },
                new ProductTranslation()
                {
                    Id = 2,
                    ProductId = 1,
                    Name = "Specialty Coffee",
                    LanguageId = "en-US",
                    SeoAlias = "specialty-coffee",
                    SeoDescription = "Arabica coffee with SCA score above 80 points",
                    SeoTitle = "Arabica coffee with SCA score above 80 points",
                    Details = "Product Description",
                    Description = ""
                }
            );

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory(){
                    CategoryId = 1,
                    ProductId = 1
                }
            );
        }
    }
}
