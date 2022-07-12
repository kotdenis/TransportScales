using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TransportScales.Test.Infrostrucure
{
    public abstract class BaseTest<TDependencyRegistrator> : IAsyncLifetime, IDisposable
        where TDependencyRegistrator : IDependencyRegistrator, new()
    {
        #region Private fields

        private static readonly Lazy<IServiceProvider> _serviceProvider
            = new Lazy<IServiceProvider>(() => new TDependencyRegistrator().GetServiceProvider(),
                LazyThreadSafetyMode.ExecutionAndPublication);
        private readonly IServiceScope _serviceScope;

        #endregion

        protected IServiceProvider ServiceProvider => _serviceScope.ServiceProvider;

        protected BaseTest()
        {
            _serviceScope = _serviceProvider.Value.CreateScope();
        }

        public virtual Task InitializeAsync() => Task.CompletedTask;
        public virtual Task DisposeAsync() => Task.CompletedTask;

        public void Dispose()
        {
            _serviceScope?.Dispose();
        }
    }
}
