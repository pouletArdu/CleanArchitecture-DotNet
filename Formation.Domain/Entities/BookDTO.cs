namespace Formation.Domain.Entities
{
    public class BookDTO : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public AuthorDTO Autor { get; set; }
        public int AutorId { get; set; }

        public BookDTO()
        {
        }
    }
}
