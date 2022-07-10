using TransportScales.Dto.DtoModels;

namespace TransportScales.Core.Services.Interfaces
{
    public interface ITransportService
    {
        Task<TransportDto> GetRandomTransportAsync(CancellationToken ct);
        Task<List<JournalDto>> SaveTransportWeightAsync(JournalDto journalDto, CancellationToken ct);
        Task CreateNewTransportAsync(TransportDto transportDto, CancellationToken ct);
    }
}
