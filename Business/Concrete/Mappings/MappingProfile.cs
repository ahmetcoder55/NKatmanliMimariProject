using AutoMapper;
using Business.Concrete.Dtos;
using Entities.Concrete;

namespace Business.Concrete.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<Product,ProductCreateDto>().ReverseMap();
            CreateMap<Product,ProductUpdateDto>().ReverseMap();

        }
    }
}