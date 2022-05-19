global using AutoMapper;
using Formation.Application.Authors.Commands.CreateAuthor;
using Formation.Application.Common.Model;
using Formation.Domain.Entities;

namespace Formation.Data.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorDTO, Author>().ReverseMap();
            CreateMap<CreateAuthorCommand, Author>().ReverseMap();
            CreateMap<PaginatedList<AuthorDTO>, PaginatedList<Author>>()
                .IncludeAllDerived()
                .ForPath(dest => dest.Items, act => act.MapFrom(org => org.Items))
                .ReverseMap();


            CreateMap<BookDTO, Book>().ReverseMap();
            CreateMap<PaginatedList<BookDTO>, PaginatedList<Book>>()
                .IncludeAllDerived()
                .ForPath(dest => dest.Items, act => act.MapFrom(org => org.Items));
        }
    }
}
