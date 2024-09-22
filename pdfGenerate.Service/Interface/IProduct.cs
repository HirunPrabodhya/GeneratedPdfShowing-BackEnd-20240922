using pdfGenerate.Service.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfGenerate.Service.Interface
{
    public interface IProduct
    {
        Task<string?> CreateProductAsync(ProductAddDto productDto, CancellationToken cancellationToken);
        Task<IQueryable<AllProductsGetDtos>?> GetAllProductsAsync(CancellationToken cancellationToken);
    }
}
