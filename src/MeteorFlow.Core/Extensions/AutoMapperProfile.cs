using AutoMapper;
using MeteorFlow.Domain.Utils;
using Newtonsoft.Json;

namespace MeteorFlow.Core.Extensions;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Domain.AppSettings, Entities.AppSettings>();
        CreateMap<Entities.AppSettings, Domain.AppSettings>();

        CreateMap<Domain.Profiles, Entities.Profiles>()
            .ForMember(dest => dest.AddressJson, act => act.MapFrom(src => JsonConvert.SerializeObject(src.Address)));
        CreateMap<Entities.Profiles, Domain.Profiles>()
            .ForMember(dest => dest.Address,
                act => act.MapFrom(src => JsonConvert.DeserializeObject<Address>(src.AddressJson)));
        CreateMap<Domain.Accounts, Entities.Account>()
            .ForMember(dest => dest.UserId, act => act.MapFrom(src => src.Profile.Id));
        CreateMap<Entities.Account, Domain.Accounts>();
        
        CreateMap<Domain.Stations, Entities.Stations>();
        CreateMap<Entities.Stations, Domain.Stations>();
        
        CreateMap<Domain.ObservationElements, Entities.ObservationElements>()
            .ForMember(dest => dest.ParentId, act => act.MapFrom(src => src.Parent.Id));
        CreateMap<Entities.ObservationElements, Domain.ObservationElements>();
        
        CreateMap<Domain.ObservationValues, Entities.ObservationValues>();
        CreateMap<Entities.ObservationValues, Domain.ObservationValues>();
        
        CreateMap<Domain.Units, Entities.Units>();
        CreateMap<Entities.Units, Domain.Units>();
    }
}