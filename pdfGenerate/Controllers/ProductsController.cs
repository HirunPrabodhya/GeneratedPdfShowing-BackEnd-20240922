using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pdfGenerate.Service.DTOS;
using pdfGenerate.Service.Interface;

namespace pdfGenerate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _product; 
        public ProductsController(IProduct product)
        {
            _product = product;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductAddDto productDto, CancellationToken cancellationToken)
        {
            var message = await _product.CreateProductAsync(productDto, cancellationToken);
            if (message == null)
            {
                return BadRequest(new
                {
                    message = "input data is not completed"
                });
            }
            return Ok(new 
            {
                message = message
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken)
        {
            var products = await _product.GetAllProductsAsync(cancellationToken);
            if(products == null)
            {
                return NotFound(
                        new
                        {
                            message = "product does not exist"
                        }
                    ) ;
            }
            return Ok(products);
        }
    }
}
