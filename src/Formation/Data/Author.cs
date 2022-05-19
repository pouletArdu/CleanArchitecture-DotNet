using Formation.Data.Common;
using Formation.Domain.Enums;

namespace Formation.Data
{
    public class Author : Paginated
    {
        [Data("Id", 1)]
        public int Id { get; set; }

        [Data("Prénom", 2)]
        public string FirstName { get; set; }

        [Data("Nom", 3)]
        public string LastName { get; set; }

        [Data("Date de naissance", 4)]
        public DateTime BirthDay { get; set; } = DateTime.Now.Date.AddYears(-18);

        [Data("Genre", 5)]
        public Gender Gender { get; set; }
    }
}
