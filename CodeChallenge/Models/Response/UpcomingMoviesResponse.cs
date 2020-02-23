using CodeChallenge.Models.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Models.Response
{
    public class UpcomingMoviesResponse : SearchResponse
    {
        public DateRange Dates { get; set; }
    }
}
