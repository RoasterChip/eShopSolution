﻿using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Catalog.Products.Public;
using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface iProductServicePublic
    {
        public Task<PageViewModel<ProductViewModel>>
            GetAllByCategoryId(GetProductPagingRequest request);
    }
}
