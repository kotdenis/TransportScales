using TransportScales.Data.Entities;
using TransportScales.Dto.DtoModels;

namespace TransportScales.Data.Repositries.Interfaces
{
    public interface IJournalRepository : IGenericRepository<Journal>
    {
        Task<IEnumerable<Journal>> SearchByNumberandDateAsync(SearchModel searchModel, CancellationToken ct);
    }
}
