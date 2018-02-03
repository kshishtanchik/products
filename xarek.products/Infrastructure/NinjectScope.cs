using Ninject;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace xarek.products.domain.Infrastructure
{
    public class NinjectScope : IDependencyScope
    {
        protected IResolutionRoot resolver;

        public NinjectScope(IResolutionRoot kernel)
        {
            resolver = kernel;
        }

        public object GetService(Type serviceType)
        {
            IRequest request = resolver.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolver.Resolve(request).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = resolver.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolver.Resolve(request).ToList();
        }

        public void Dispose()
        {
            var disposable = resolver as IDisposable;
            if (disposable != null)
                disposable.Dispose();

            resolver = null;
        }
    }
}