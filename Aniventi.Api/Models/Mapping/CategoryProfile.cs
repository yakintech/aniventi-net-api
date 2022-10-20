using Aniventi.DAL.ORM.Entity;
using Aniventi.Dto.Models.Category;
using AutoMapper;

namespace Aniventi.Api.Models.Mapping
{
    public class CategoryProfile : Profile
    {

        public CategoryProfile()
        {
            CreateMap<Category, CategoryListDto>()
                .ForMember(dest => dest.Bid, opt => opt.MapFrom(src => src.BrandId))
                .AfterMap((_, dest) =>
                {
                    dest.StatusDate = DateTime.Now;
                });

        }

    }
}
