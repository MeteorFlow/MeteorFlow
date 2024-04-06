using AutoMapper;
using MeteorFlow.Core.Entities.App;
using MeteorFlow.Domain.Tenants;
using MeteorFlow.Domain.Utils;
using Newtonsoft.Json;

namespace MeteorFlow.Core.Extensions;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Domain.App.AppSettings, AppSettings>();
        CreateMap<AppSettings, Domain.App.AppSettings>();

        CreateMap<Domain.Users, Entities.Users>()
            .ForMember(dest => dest.AddressJson, act => act.MapFrom(src => JsonConvert.SerializeObject(src.Address)));
        CreateMap<Entities.Users, Domain.Users>()
            .ForMember(dest => dest.Address,
                act => act.MapFrom(src => JsonConvert.DeserializeObject<Address>(src.AddressJson)));
        // CreateMap<Domain.Accounts, Entities.Account>()
        //     .ForMember(dest => dest.ProfileId, act => act.MapFrom(src => src.User.Id));
        // CreateMap<Entities.Account, Domain.Accounts>();
        
        CreateMap<Tenants, Entities.Tenants>();
        CreateMap<Entities.Tenants, Tenants>();
        
        // CreateMap<Domain.ObservationElements, Entities.ObservationElements>()
        //     .ForMember(dest => dest.ParentId, act => act.MapFrom(src => src.Parent.Id));
        // CreateMap<Entities.ObservationElements, Domain.ObservationElements>();
        //
        // CreateMap<Domain.ObservationValues, Entities.ObservationValues>();
        // CreateMap<Entities.ObservationValues, Domain.ObservationValues>();
        //
        // CreateMap<Domain.Units, Entities.Units>();
        // CreateMap<Entities.Units, Domain.Units>();
        
        
    }
}