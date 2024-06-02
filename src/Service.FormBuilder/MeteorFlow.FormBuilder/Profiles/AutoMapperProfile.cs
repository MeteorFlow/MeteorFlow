using AutoMapper;
using MeteorFlow.Domain.App;
using MeteorFlow.FormBuilder.Models;
using Newtonsoft.Json;

namespace MeteorFlow.FormBuilder.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<FormDefinition, AppDefinitions>();
        CreateMap<AppDefinitions, FormDefinition>()
            .AfterMap((_, dest) =>
                JsonConvert.DeserializeObject<AppDefinitions>(JsonConvert.SerializeObject(dest)));

        CreateMap<FormBlock, Entities.FormBlocks>()
            .ForMember(dest => dest.SchemaId, act => act.MapFrom(src => src.Schema.Id))
            .ForMember(dest => dest.ElementId, act => act.MapFrom(src => src.Element.Id))
            .ForMember(dest => dest.Element, act => act.Ignore())
            .ReverseMap();
        CreateMap<FormElement, Entities.FormElements>().ReverseMap();
        CreateMap<ElementSchema, Entities.ElementSchemas>().ReverseMap();
        
    }
}