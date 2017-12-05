using Ninject;
using AppArchitecture.BL.CalculateDates.Contracts;
using AppArchitecture.BL.CalculateDates.Services;
using AppArchitecture.BL.DALContracts;
using AppArchitecture.DAL.RepositoryService.CalculateDates;
using System;
using System.Collections.Generic;

namespace AppArchitecture.DIContainer
{
    public sealed class AppArchitectureNInjectKernel
    {
        /// <summary>
        ///     A factory that creates objects of the configured types.
        /// </summary>
        private IKernel _kernel;

        public AppArchitectureNInjectKernel()
        {
            this._kernel = new StandardKernel();
            this.BindAllDependencies();
        }

        private void BindAllDependencies()
        {
            _kernel.Bind<ICalculateDatesContract>().To<CalculateDatesRepository>();
            _kernel.Bind<ICalculateDatesService>().To<CalculateDatesService>();
        }

        /// <summary>
        ///     Gets a service of the provided type.
        /// </summary>
        /// <param name="serviceType">The type of the requested service.</param>
        /// <returns>An object representing the requested service.</returns>
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        /// <summary>
        ///     Gets all the registered services of the provided type.
        /// </summary>
        /// <param name="serviceType">The type of the requested services.</param>
        /// <returns>A collection of objects representing the requested services.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}
