using Microsoft.EntityFrameworkCore;
using pdfGenerate.Data;
using pdfGenerate.Model;
using pdfGenerate.Service.DTOS;
using pdfGenerate.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfGenerate.Service.Implementation
{
    public class ProductService : IProduct
    {
        private readonly ProductDbContext _dbContext;
        public ProductService(ProductDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public async Task<string?> CreateProductAsync(ProductAddDto productDto, CancellationToken cancellationToken)
        {
            if(productDto == null)
            {
                return null;
            }
            var product = new Product
            {
                ProductName = productDto.ProductName,
                Description = productDto.Description,
                UnitPrice = productDto.UnitPrice,
            };
             await _dbContext.Product.AddAsync(product,cancellationToken);
            int count =  await _dbContext.SaveChangesAsync(cancellationToken);
            if (count <= 0)
            {
                return "product is not saved";
            }
            return "product is saved";

        }

        public async Task<IQueryable<AllProductsGetDtos>?> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            var products = await _dbContext.Product.ToListAsync(cancellationToken);
            if(products == null)
            {
                return null;
            }
            var productsDto = products.Select(x => new AllProductsGetDtos
            {
                Id = x.Id,
                ProductName = x.ProductName,
                Description = x.Description,
                UnitPrice = x.UnitPrice
            }).AsQueryable();

            return productsDto;

        }
    }
}
