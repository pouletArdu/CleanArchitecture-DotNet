namespace Formation.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDTO, Book>()
                .ReverseMap();

            CreateMap<AuthorDTO, Author>().ReverseMap()
                .IncludeAllDerived();
        }
    }
}
