using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Models.Data
{
    public class Movie
    {
        public int Id { get; set; }

        public string BackdropPath { get; set; }

        public List<int> GenreIds { get; set; }

        public string Overview { get; set; }

        public string PosterPath { get; set; }

        public DateTimeOffset ReleaseDate { get; set; }

        public string Title { get; set; }
    }
}
