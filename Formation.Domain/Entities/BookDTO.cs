namespace Formation.Domain.Entities
{
    public class BookDTO : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public AuthorDTO Author { get; set; }
        public int AuthorId { get; set; }

        public static builder CreateBuilder() => new builder();

        public class builder
        {
            private readonly BookDTO book;
            public builder() => book = new BookDTO();

            public builder WithTitle(string title)
            {
                book.Title = title;
                return this;
            }

            public builder WithAuthorId(int authorId)
            {
                book.AuthorId = authorId;
                return this;
            }

            public builder WithDescription(string description)
            {
                book.Description = description;
                return this;
            }

            public BookDTO Build() => book;
        }
    }


}
