using pdfGenerate.Service.Interface;
using pdfGenerate.Service.PDFGeneratorClass;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfGenerate.Service.Implementation
{
    public class PDFService : IPDF
    {
        private readonly IProduct _product;

        public PDFService(IProduct product)
        {
            _product = product;
        }

        public async Task<byte[]?> DownloadPdfAsync(CancellationToken cancellationToken)
        {
            var products = await _product.GetAllProductsAsync(cancellationToken);
            if (products == null)
            {
                return null;
            }
            var document = PdfCreation.createPdfContent(products);

            
            return document.GeneratePdf();
        }
      
    }
}
