using AutoMapper;
using MeteorFlow.Core.Entities;
using Newtonsoft.Json;

namespace MeteorFlow.Core.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Domain.App.AppSettings, AppSettings>().ReverseMap();

        CreateMap<Domain.App.AppVersionControls, AppVersionControls>().ReverseMap();

        CreateMap<Domain.App.AppDefinitions, AppDefinitions>();

        CreateMap<AppDefinitions, Domain.App.AppDefinitions>()
            .AfterMap((_, dest) =>
                JsonConvert.DeserializeObject<Domain.App.AppDefinitions>(JsonConvert.SerializeObject(dest)));

        CreateMap<Domain.App.AppInstances, AppInstances>().ReverseMap();

        // CreateMap<Users, Entities.Identities.Users>()
        //     .ForMember(dest => dest.AddressJson, act => act.MapFrom(src => JsonConvert.SerializeObject(src.Address)));
        // CreateMap<Entities.Identities.Users, Users>()
        //     .ForMember(dest => dest.Address,
        //         act => act.MapFrom(src => JsonConvert.DeserializeObject<Address>(src.AddressJson)));
        // CreateMap<Domain.Accounts, Entities.Account>()
        //     .ForMember(dest => dest.ProfileId, act => act.MapFrom(src => src.Users.Id));
        // CreateMap<Entities.Account, Domain.Accounts>();


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