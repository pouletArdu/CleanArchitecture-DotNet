namespace Formation.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDTO, Book>()
                .ReverseMap()
                .IncludeAllDerived()
                .ForMember(dest => dest.AutorId, act => act.MapFrom(org => org.Author.Id));

            CreateMap<AuthorDTO, Author>()
                .ReverseMap();
        }
    }
}
