using pdfGenerate.Service.DTOS;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfGenerate.Service.PDFGeneratorClass
{
     class PdfCreation
    {
        internal static Document createPdfContent(IQueryable<AllProductsGetDtos> products)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Header().Text("Product List Report").FontSize(40).FontColor(Color.FromRGB(0, 0, 0));
                    page.Content().Border(1).Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(2);
                            columns.RelativeColumn(1);
                        });
                        table.Header(header =>
                        {
                            header.Cell().Element(Block).Text("Product Id").Bold();
                            header.Cell().Element(Block).Text("Product Name").Bold();
                            header.Cell().Element(Block).Text("Description").Bold();
                            header.Cell().Element(Block).Text("Unit Price").Bold();

                        });
                        foreach (var product in products)
                        {
                            table.Cell().Element(Block).Text(product.Id.ToString());
                            table.Cell().Element(Block).Text(product.ProductName);
                            table.Cell().Element(Block).Text(product.Description);
                            table.Cell().Element(Block).Text(product.UnitPrice.ToString());
                        }
                    });
                });
            });
            return document;
        }
        private static IContainer Block(IContainer container)
        {
            return container
                .Border(1)
                .AlignCenter();
        }
    }
}
