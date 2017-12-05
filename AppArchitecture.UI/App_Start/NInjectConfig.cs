using AppArchitecture.DIContainer;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AppArchitecture.UI.App_Start
{
    public class NInjectConfig
    {
        /// <summary>
        /// Sets the dependency resolver.
        /// </summary>
        public static void SetupDependencyInjection()
        {
            DependencyResolver.SetResolver(new NInjectDepedencyResolver());
        }

        public class NInjectDepedencyResolver : IDependencyResolver
        {

            /// <summary>
            /// The NInject kernel.
            /// </summary>
            private AppArchitectureNInjectKernel _kernel;

            /// <summary>
            /// Initializes a new instance of the <see cref="NInjectDepedencyResolver" /> class.
            /// </summary>
            /// <param name="kernel">The NInject kernel to be used.</param>
            public NInjectDepedencyResolver()
            {
                _kernel = new AppArchitectureNInjectKernel();
            }

            public object GetService(Type serviceType)
            {
                return _kernel.GetService(serviceType);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return _kernel.GetServices(serviceType);
            }
        }
    }
}