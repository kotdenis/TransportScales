using AutoMapper;
using TransportScales.Data.Entities;
using TransportScales.Dto.DtoModels;

namespace TransportScales.Core.Configuration
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<JournalDto, Journal>()
                .ForMember(x => x.IsDeleted, _ => _.Ignore())
                .ForMember(x => x.Created, _ => _.Ignore())
                .ForMember(x => x.Updated, _ => _.Ignore())
                .ForMember(x => x.Id, _ => _.Ignore());

            CreateMap<Journal, JournalDto>();

            CreateMap<TransportDto, Transport>()
                .ForMember(X => X.IsDeleted, _ => _.Ignore())
                .ForMember(x => x.Created, _ => _.Ignore())
                .ForMember(x => x.Updated, _ => _.Ignore());

            CreateMap<Transport, TransportDto>();
        }
    }
}
