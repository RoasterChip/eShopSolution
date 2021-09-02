using eShopSolution.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Catalog.Products.DTOs
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }

        public List<int> CategoryIDs { get; set; }
    }
}
