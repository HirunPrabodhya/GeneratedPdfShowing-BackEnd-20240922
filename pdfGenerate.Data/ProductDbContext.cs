using Microsoft.EntityFrameworkCore;
using pdfGenerate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdfGenerate.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public ProductDbContext(DbContextOptions<ProductDbContext> option) : base(option)
        {
            
        }
    }
}
