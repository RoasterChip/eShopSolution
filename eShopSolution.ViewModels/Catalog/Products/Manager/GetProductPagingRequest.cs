using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.Products.Manager
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }

        public List<int> CategoryIDs { get; set; }
        public object CategoryId { get; set; }
    }
}
