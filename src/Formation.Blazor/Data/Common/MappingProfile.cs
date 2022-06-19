global using AutoMapper;
using Formation.Application.Authors.Commands.CreateAuthor;
using Formation.Application.Authors.Commands.UpdateAuthor;
using Formation.Application.Books.Commands.CreateBook;
using Formation.Application.Books.Commands.UpdateBook;
using Formation.Application.Common.Model;
using Formation.Domain.Entities;

namespace Formation.Blazor.Data.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AuthorDTO, Author>().ReverseMap();
        CreateMap<CreateAuthorCommand, Author>();
        CreateMap<UpdateAuthorCommand, AuthorDTO>().ReverseMap();
        CreateMap<UpdateAuthorCommand, Author>();
        CreateMap<PaginatedList<AuthorDTO>, PaginatedList<Author>>()
            .IncludeAllDerived()
            .ForPath(dest => dest.Items, act => act.MapFrom(org => org.Items))
            .ReverseMap();


        CreateMap<BookDTO, Book>().ReverseMap();
        CreateMap<CreateBookCommand, Book>();
        CreateMap<UpateBookCommand, BookDTO>().ReverseMap();
        CreateMap<UpateBookCommand, Book>();

        CreateMap<PaginatedList<BookDTO>, PaginatedList<Book>>()
            .IncludeAllDerived()
            .ForPath(dest => dest.Items, act => act.MapFrom(org => org.Items));
    }
}
