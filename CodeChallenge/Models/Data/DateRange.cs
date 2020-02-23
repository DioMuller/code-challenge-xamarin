using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Models.Data
{
    public class DateRange
    {
        public DateTimeOffset Maximum { get; set; }

        public DateTimeOffset Minimum { get; set; }
    }
}
