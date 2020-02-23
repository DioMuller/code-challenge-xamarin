using CodeChallenge.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Models.Response
{
    public class SearchResponse
    {
        public List<Movie> Results { get; set; }

        public int Page { get; set; }

        public int TotalResults { get; set; }

        public int TotalPages { get; set; }
    }
}
