using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pdfGenerate.Service.Interface;

namespace pdfGenerate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFsController : ControllerBase
    {
        private readonly IPDF _pdf;
       
        public PDFsController(IPDF pdf)
        {
            _pdf = pdf;
        }
        [HttpGet]
        public async Task<IActionResult> DownloadPdf(CancellationToken cancellationToken) 
        {
            var pdfConent = await _pdf.DownloadPdfAsync(cancellationToken);
            if(pdfConent == null)
            {
                return NotFound(new
                {
                    message = "content is not found"
                });
            }
            return File(pdfConent, "application/pdf", "ProductList.pdf");
        }
    }
}
