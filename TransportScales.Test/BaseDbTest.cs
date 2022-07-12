using System.Threading.Tasks;
using TransportScales.Data;
using TransportScales.Test.Infrostrucure;

namespace TransportScales.Test
{
    public class BaseDbTest : BaseDbTest<Startup, TransportDbContext>
    {
        protected override async Task SeedAsync()
        {
            await SeedInMemoryData.PopulateAsync(ServiceProvider);
        }
    }
}
