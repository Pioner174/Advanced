﻿using System.Text.Json.Serialization;

namespace Advanced.Models
{
    public class Location
    {
        public long LocationId { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public IEnumerable<Person>? People { get; set; }
    }
}

