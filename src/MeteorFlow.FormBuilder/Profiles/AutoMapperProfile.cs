using AutoMapper;
using MeteorFlow.Domain.App;
using MeteorFlow.FormBuilder.Models;
using Newtonsoft.Json;

namespace MeteorFlow.FormBuilder.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<FormDefinitions, Core.Entities.AppDefinitions>();
        CreateMap<Core.Entities.AppDefinitions, FormDefinitions>()
            .AfterMap((_, dest) =>
                JsonConvert.DeserializeObject<AppDefinitions>(JsonConvert.SerializeObject(dest)));

        CreateMap<FormBlocks, Entities.FormBlocks>().ReverseMap();
        CreateMap<FormElements, Entities.FormElements>().ReverseMap();
        CreateMap<ElementSchemas, Entities.ElementSchemas>().ReverseMap();
        
    }
}