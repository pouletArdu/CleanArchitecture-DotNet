using Formation.Application.Authors.Commands.CreateAuthor;
using Formation.Application.Authors.Commands.UpdateAuthor;
using Formation.Application.Books.Commands.CreateBook;

namespace Formation.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookCommand, BookDTO>();
            CreateMap<CreateAuthorCommand, AuthorDTO>();
            CreateMap<UpdateAuthorCommand, AuthorDTO>();
        }
    }
}
