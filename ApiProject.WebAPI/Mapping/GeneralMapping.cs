using ApiProject.WebAPI.Dtos.FeatureDtos;
using ApiProject.WebAPI.Dtos.MessageDtos;
using ApiProject.WebAPI.Entities;
using AutoMapper;

namespace ApiProject.WebAPI.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
            //-----------------------------------------------------
            CreateMap<ContactMessage, ResultMessageDto>().ReverseMap();
            CreateMap<ContactMessage, CreateMessageDto>().ReverseMap();
            CreateMap<ContactMessage, GetByIdMessageDto>().ReverseMap();
            CreateMap<ContactMessage, UpdateMessageDto>().ReverseMap();
        }
    }
}
