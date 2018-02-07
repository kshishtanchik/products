using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xarek.products.domain.Entities;
using xarek.products.domain.interfaces;

namespace xarek.products.domain.Implementation
{
    public class DBProductRepo : IproductREPO
    {
        private ProductsContext productsContext = new ProductsContext();
        public void DeleteItem(int DelProduct)
        {
            var item = productsContext.Products.FirstOrDefault(x => x.ProductId == DelProduct);
            productsContext.Products.Remove(item);
            productsContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return productsContext.Products.ToList();
        }

        public Product GetItem(int i) => productsContext.Products.FirstOrDefault(x => x.ProductId == i);

        public void SaveItem(Product product)
        {
            if (product.ProductId == 0)
            {
                productsContext.Products.Add(product);
            }
            else
            {
                var item = productsContext.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
                item.ProductName = product.ProductName;
                item.Price = product.Price;
                item.Count = product.Count;
            }
            productsContext.SaveChanges();
        }

    }
}
