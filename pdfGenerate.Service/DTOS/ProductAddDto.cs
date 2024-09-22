using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfGenerate.Service.DTOS
{
    public class ProductAddDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
    }
}
