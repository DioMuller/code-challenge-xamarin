using CodeChallenge.Models.Data;
using System.Collections.Generic;

namespace CodeChallenge.Models
{
    public class SearchResult
    {
        public List<Movie> Results { get; set; }

        public int Page { get; set; }

        public int TotalResults { get; set; }

        public int TotalPages { get; set; }

        public DateRange Dates { get; set; }
    }
}
