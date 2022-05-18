global using AutoMapper;
using Formation.Application.Common.Model;
using Formation.Domain.Entities;

namespace Formation.Data.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorDTO, Author>().ReverseMap();
            CreateMap<BookDTO, Book>().ReverseMap();
            CreateMap<PaginatedList<BookDTO>, PaginatedList<Book>>()
                .IncludeAllDerived()
                .ForPath(dest => dest.Items, act => act.MapFrom(org => org.Items));
            //.ForMember(dest => dest.HasNextPage, act => act.MapFrom(org => org.HasNextPage))
            //.ForMember(dest => dest.HasPreviousPage, act => act.MapFrom(org => org.HasPreviousPage))
            //.ForMember(dest => dest.Items, act => act.MapFrom(org => org.Items));
        }
    }
}
