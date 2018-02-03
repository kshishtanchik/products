using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using xarek.products.domain.Entities;
using xarek.products.domain.interfaces;

namespace xarek.products.Controllers
{
    public class ValuesController : ApiController
    {
        private IproductREPO productrepo;
        public ValuesController(IproductREPO productrepo) {
            this.productrepo = productrepo;
        }

        // GET api/values
        //public Product Get(int i=0)
        //{
        //    return productrepo.GetItem(i);
        //}

        // GET api/values/5
        public List<Product> Get()
        {
            return productrepo.GetAll();
        }

        // POST api/values
        public void Post([FromBody]Product value)
        {
        productrepo.SaveItem(value);
        }

        // PUT api/values/5
        //public void Put(int id, [FromBody]Product value)
        //{
        //    productrepo.ChangeItem(id, value);
        //}
        // DELETE api/values/5
        public void Delete(int id)
        {
            productrepo.DeleteItem(id);
        }
    }
}
