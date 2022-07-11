using TransportScales.Data.Entities;
using TransportScales.Data.Repositries.Interfaces;

namespace TransportScales.Data.Repositries.Implementation
{
    public class TransportRepository : GenericRepository<Transport>, ITransportRepository
    {
        public TransportRepository(TransportDbContext transportDbContext) : base(transportDbContext)
        {
           
        }
    }
}
