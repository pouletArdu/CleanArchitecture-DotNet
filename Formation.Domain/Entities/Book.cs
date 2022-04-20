namespace Formation.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public Autor Autor { get; set; }
    }
}
