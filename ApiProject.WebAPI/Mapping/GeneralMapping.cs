using ApiProject.WebAPI.Dtos.FeatureDtos;
using ApiProject.WebAPI.Dtos.MessageDtos;
using ApiProject.WebAPI.Dtos.ProductDtos;
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
            //-----------------------------------------------------
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategory>().ForMember(x => x.CategoryName,
                y => y.MapFrom(z => z.Category.Name)).ReverseMap();
        }
    }
}
