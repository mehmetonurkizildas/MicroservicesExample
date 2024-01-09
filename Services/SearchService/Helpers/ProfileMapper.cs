
using AutoMapper;
using Events;
using SearchService.Models;

namespace SearchService.Helpers
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {

            CreateMap<ProductCreated, Product>();
            CreateMap<ProductUpdated, Product>();
        }
    }
}
