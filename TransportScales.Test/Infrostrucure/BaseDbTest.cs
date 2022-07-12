using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportScales.Test.Infrostrucure
{
    public abstract class BaseDbTest<TDependencyRegistrator, TDbContext> : BaseTest<TDependencyRegistrator>
        where TDependencyRegistrator : IDependencyRegistrator, new()
        where TDbContext : DbContext
    {
        protected TDbContext DbContext { get; }

        protected BaseDbTest()
        {
            DbContext = ServiceProvider.GetRequiredService<TDbContext>();
        }

        public override async Task InitializeAsync()
        {
            await SeedAsync();
        }

        protected virtual Task SeedAsync() => Task.CompletedTask;
    }
}
