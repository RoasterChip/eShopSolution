using eShopSolution.Application.Catalog.Products.DTOs;
using eShopSolution.Application.DTOs;
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

        Task<List<ProductViewModel>> GetAll();

        Task<PageViewModel<ProductViewModel>>
            GetAllPaging(GetProductPagingRequest request);
    }
}
