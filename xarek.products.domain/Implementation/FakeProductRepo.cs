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
        public Product GetItem(int i)
        {
            return products.ElementAt(i);
                //throw new NotImplementedExceprtion();
        }
        public List<Product> GetAll()
        {
            return products;
            
        }

        
        /// <summary>
        /// Добавление
        /// </summary>
        public void AddItem(Product NewProduct)
        {
            products.Add(NewProduct);
        }
        /// <summary>
        /// удаление
        /// </summary>       
        public void DeleteItem(int DelProduct)
        {
            var xyu = products.FirstOrDefault(x => x.ProductId == DelProduct);
            products.Remove(xyu);
        }
        // добавление изменеие удаление
        /// <summary>
        /// Форирование элемента
        /// </summary>
        public void SaveItem(Product product)
        {
            var xyu = products.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (xyu == null)
            {
                products.Add(product);
            }
            else
            {
                xyu.ProductName = product.ProductName;
                xyu.Price = product.Price;
                xyu.Count = product.Count;
            };
        }

    }
}
