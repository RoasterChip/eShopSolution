﻿using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Exceptions;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Catalog.Products.Manager;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public class ProductServiceManager : iProductServiceManager
    {
        private readonly EShopDbContext _context;
        private readonly iStorageService _storageService;

        public ProductServiceManager(EShopDbContext context, iStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task AddViewCount(int ProductId)
        {
            var product = await _context.Products.FindAsync(ProductId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            //add new product
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId
                    }
                }
            };
            //save product image
            if(request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "thumbnail Image",
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImageURL = await this.SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFilename = ContentDispositionHeaderValue
                                            .Parse(file.ContentDisposition)
                                            .FileName.Trim(' ');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFilename)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
         }


        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTraslation = await _context.ProductTranslations
                                                        .FirstOrDefaultAsync(x => x.ProductId == request.Id 
                                                                                    && x.LanguageId == request.LanguageId);

            if (product == null || productTraslation == null) 
                throw new eShopException($"Connot find a product: {request.Id}");
            //update product
            {
                productTraslation.Name = request.Name;
                productTraslation.Description = request.Description;
                productTraslation.Details = request.Details;
                productTraslation.SeoAlias = request.SeoAlias;
                productTraslation.SeoDescription = request.SeoDescription;
                productTraslation.SeoTitle = request.SeoTitle;
            }
            //update product image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.ProductImages
                                                            .FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Id);
                if(thumbnailImage != null)
                {
                    thumbnailImage.ImageURL = await this.SaveFile(request.ThumbnailImage);
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    _context.ProductImages.Update(thumbnailImage);
                }
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int ProductId)
        {
            var product = await _context.Products.FindAsync(ProductId);
            if (product == null)
                throw new eShopException($"Cannot find a product: {ProductId}");
            else
            {
                //delete product image
                var images = _context.ProductImages
                                                .Where(i => i.ProductId == ProductId);
                foreach (var image in images)
                {
                    await _storageService.DeleteFileAsync(image.ImageURL);
                }
                //delete product
                _context.Products.Remove(product);
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePrice(int ProductId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(ProductId);
            if (product == null)
                throw new eShopException($"Connot find a product: {ProductId}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int ProductId, int addQuantity)
        {
            var product = await _context.Products.FindAsync(ProductId);
            if (product == null)
                throw new eShopException($"Connot find a product: {ProductId}");
            product.Stock += addQuantity;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<PageViewModel<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            //1. Select
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        where pt.Name.Contains(request.keyword)
                        select new { p, pt, pic };

            //2. Filter
            if (string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.pt.Name.Contains(request.keyword));
            if(request.CategoryIDs.Count > 0)
            {
                query = query.Where(p => request.CategoryIDs.Contains(p.pic.CategoryId));
            }

            //3. Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1)*request.pageSize)
                                    .Take(request.pageSize)
                                    .Select(x => new ProductViewModel() 
                                    {
                                        Id = x.p.Id,
                                        Name = x.pt.Name,
                                        OriginalPrice = x.p.OriginalPrice,
                                        Price = x.p.Price,
                                        Stock = x.p.Stock,
                                        ViewCount = x.p.ViewCount,
                                        DateCreated = x.p.DateCreated,

                                        Description = x.pt.Description,
                                        Details = x.pt.Details,
                                        LanguageId = x.pt.LanguageId,
                                        SeoAlias = x.pt.SeoAlias,
                                        SeoDescription = x.pt.SeoDescription,
                                        SeoTitle = x.pt.SeoTitle
                                    }).ToListAsync();
            //ví dụ pagesize = 10
            //take pagesize: lấy 10 bản ghi cho vào trang đầu (pageIndex = 1), skip (1-1)*10 = 0 bản ghi
            //lấy tiếp 10 bản ghi tiếp theo (pageIndex = 2), skip (2-1)*10 = 10 bản ghi đã lấy
            //lấy tiếp 10 bản ghi tiếp theo (pageIndex = 3), skip (3-1)*10 = 20 bản ghi đã lấy


            //4. Select and projection
            var pageViewModel = new PageViewModel<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pageViewModel;
        }
    }
}
