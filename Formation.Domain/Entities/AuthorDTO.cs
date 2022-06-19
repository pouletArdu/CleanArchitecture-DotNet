namespace Formation.Domain.Entities
{
    public class AuthorDTO : BaseEntity, IHasDomainEvent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public ICollection<BookDTO> Books { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        public override string ToString()
        {
            return $"{(Gender == Gender.Male ? "Mr" : "Mdm")} {FirstName} {LastName}";
        }
    }
}