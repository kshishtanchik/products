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

        /// <summary>
        /// Удаление элемента
        /// </summary>
        /// <param name="DelProduct"></param>
        public void DeleteItem(int DelProduct)
        {
            var item = productsContext.Products.FirstOrDefault(x => x.ProductId == DelProduct);
            productsContext.Products.Remove(item);
            productsContext.SaveChanges();
        }

        /// <summary>
        /// Получение всех значений из базы
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAll()
        {
          return productsContext.Products.ToList();
        }

        /// <summary>
        /// Получение одной записи из базы
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Product GetItem(int i) => productsContext.Products.FirstOrDefault(x => x.ProductId == i);


        /// <summary>
        /// Запись нового элемента или созданиие нового
        /// </summary>
        /// <param name="product"></param>
        public void SaveItem(Product product)
        {
            // Определяемся создавать элемент или редактировать
            if (product.ProductId == 0)
            {
                // Создание нового продукта с содержимым
                productsContext.Products.Add(product);
                productsContext.ConsistOf.AddRange(product.Consists);
            }
            else
            {
                #region Обновление продукта

                // Обновление редактированного продукта
                var item = productsContext.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
                item.ProductName = product.ProductName;
                item.Price = product.Price;
                item.Count = product.Count;

                #endregion

                #region удаление 

                // Все элементы относящиеся к текущему продукту в таблице
                var consistsByProduct = productsContext.ConsistOf.Where(w => w.ProdId == product.ProductId).ToArray();
                // Записи для удаления, которых не было в данных от пользователя
                var recordsToDelete = consistsByProduct.Where(w => !product.Consists.Select(e => e.id).Contains(w.id));
                // Удалили элементы 
                productsContext.ConsistOf.RemoveRange(recordsToDelete);

                #endregion

                #region Обновление существующих записей

                // id удаляемых записей
                var delerIds = recordsToDelete.Select(r => r.id);
                // Элементы, которые будут обновляться
                var update = product.Consists.Where(e => e.id != 0 && !delerIds.Contains(e.id));
                if (update != null)
                {
                    foreach (Consist iter in update)
                    {
                        var upd = consistsByProduct.FirstOrDefault(x => x.id == iter.id);
                        upd.Content = iter.Content;
                        upd.countConsist = iter.countConsist;
                    }
                }

                #endregion

                #region Добавление новых составляющих

                // Элементы на добавление
                var newitem = product.Consists.Where(x => x.id == 0);
                // Привязываем запись состава к продукту
                foreach (Consist record in newitem) record.ProdId = product.ProductId;
                productsContext.ConsistOf.AddRange(newitem);

                #endregion
            }

            productsContext.SaveChanges();
        }
    }
}
