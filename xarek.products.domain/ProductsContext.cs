using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xarek.products.domain
{
    /// <summary>
    /// Контекст к  базе с продуктами и составляющими
    /// </summary>
    public class ProductsContext : DbContext
    {
        // Добавление сущности продукта
        public DbSet<Entities.Product> Products { get; set; }
        // Добавление сущности составляющей
        public DbSet<Entities.Consist> ConsistOf { get; set; }
            
    }
}
