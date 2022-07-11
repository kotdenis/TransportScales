using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportScales.Data.Entities;
using TransportScales.Data.Repositries.Interfaces;

namespace TransportScales.Data.Repositries.Implementation
{
    public class TransportQuantityRepository : GenericRepository<TransportQuantity>, ITransportQuantityRepository
    {

        public TransportQuantityRepository(TransportDbContext transportDbContext) : base(transportDbContext)
        {

        }
    }
}
