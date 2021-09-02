using eShopSolution.Application.Catalog.Products.DTOs.Public;
using eShopSolution.Application.Catalog.Products.DTOs;
using eShopSolution.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using GetProductPagingRequest = eShopSolution.Application.Catalog.Products.DTOs.Public.GetProductPagingRequest;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface iProductServicePublic
    {
        public Task<PageViewModel<ProductViewModel>>
            GetAllByCategoryId(GetProductPagingRequest request);
    }
}
