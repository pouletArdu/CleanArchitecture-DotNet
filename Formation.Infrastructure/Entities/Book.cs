namespace Formation.Infrastructure.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public Author Author { get; set; }
    }
}
