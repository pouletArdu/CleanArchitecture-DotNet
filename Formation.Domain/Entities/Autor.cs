﻿namespace Formation.Domain.Entities
{
    public class Autor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDay { get; set; }
        public Gender gender { get; set; }
    }
}