using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xarek.products.domain
{
    public class ProductsContext : DbContext
    {
        public DbSet<Entities.Product> Products { get; set; }
        //public ProductsContext():base("ProductsDB") {}
    }
}
