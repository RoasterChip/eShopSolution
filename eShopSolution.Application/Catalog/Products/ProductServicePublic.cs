using eShopSolution.Application.Catalog.Products.DTOs;
using eShopSolution.Application.DTOs;
using eShopSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eShopSolution.Application.Catalog.Products
{
    public class ProductServicePublic : iProductServicePublic
    {
        private readonly EShopDbContext _context;
        public ProductServicePublic(EShopDbContext context)
        {
            _context = context;
        }

        public async Task<PageViewModel<ProductViewModel>> GetAllByCategoryId(DTOs.Public.GetProductPagingRequest request)
        {
            //1. Select
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };

            //2. Filter
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            }

            //3. Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
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
