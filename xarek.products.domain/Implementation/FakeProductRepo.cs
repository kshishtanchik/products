using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xarek.products.domain.Entities;
using xarek.products.domain.interfaces;

namespace xarek.products.domain.Implementation
{
    public class FakeProductRepo : IproductREPO
    {
        /// <summary>
        /// наша переменная
        /// </summary>
        private static List<Product> products = new List<Product>() {
                new Product() { ProductId =0, Count=6, Price=20, ProductName="Человеческий ганглий" },
                new Product() { ProductId =1, Count=9, Price=90, ProductName="Мутированная многоножка" },
                new Product() { ProductId =2, Count=3, Price=30, ProductName="Отпиленная нога наркомана" }
        };
        public Product GetItem(int i) => products.FirstOrDefault(x => x.ProductId == i);
        public List<Product> GetAll()
        {
            return products;
            
        }    
        /// <summary>
        /// удаление
        /// </summary>       
        public void DeleteItem(int DelProduct)
        {
            var item = products.FirstOrDefault(x => x.ProductId == DelProduct);
            products.Remove(item);
        }    
        /// <summary>
        /// Форирование элемента
        /// </summary>
        public void SaveItem(Product product)
        {
            var item = products.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (item == null)
            {
                products.Add(product);
            }
            else
            {
                item.ProductName = product.ProductName;
                item.Price = product.Price;
                item.Count = product.Count;
            };
        }

    }
}
