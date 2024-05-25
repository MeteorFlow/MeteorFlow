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
    }
}