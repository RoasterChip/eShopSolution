using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Catalog.Products.Manager;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface iProductServiceManager
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<bool> UpdatePrice(int ProductId, decimal newPrice);

        Task<bool> UpdateStock(int ProductId, int updateQuantity);

        Task<int> Delete(int ProductId);

        Task AddViewCount(int ProductId);

        Task<PageViewModel<ProductViewModel>>
            GetAllPaging(GetProductPagingRequest request);

        Task<int> AddImages(int ProductId, List<IFormFile> files);

        Task<int> UpdateImages(int ImageID, string Caption, bool IsDefault);

        Task<int> RemoveImages(int ImageID);
    }
}
