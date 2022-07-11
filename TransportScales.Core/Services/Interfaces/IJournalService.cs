using TransportScales.Dto.DtoModels;

namespace TransportScales.Core.Services.Interfaces
{
    public interface IJournalService
    {
        Task<IEnumerable<JournalDto>> GetJournalDtosAsync(CancellationToken ct);
        Task<IEnumerable<JournalDto>> SearchInJournalAsync(SearchModel searchModel, CancellationToken ct);
    }
}
