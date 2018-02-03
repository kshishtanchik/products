using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xarek.products.domain.Entities
{
    public class Product
    {
       /// <summary>
       /// идентификатор товара
       /// </summary>
       public int ProductId { set; get; }
        /// <summary>
        /// Наименование товара
        /// </summary>
        public string ProductName { set; get; }
        /// <summary>
        /// Количество
        /// </summary>
        public int Count { set; get; }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { set; get; }
    }
}
