namespace Formation.Infrastructure.Entities
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender gender { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
