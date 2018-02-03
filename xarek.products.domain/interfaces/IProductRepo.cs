using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xarek.products.domain.Entities;

namespace xarek.products.domain.interfaces
{
    public interface IproductREPO
    {
        void DeleteItem(int DelProduct);
        void SaveItem(Product product);
        List<Product> GetAll();
    }
}
