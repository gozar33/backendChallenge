using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Models
{
    public class TimeRange
    {
        public TimeSpan Start { get; }
        public TimeSpan End { get; }

        public TimeRange(TimeSpan start, TimeSpan end)
        {
            Start = start;
            End = end;
        }

        public bool Contains(TimeSpan time)
        {
            return time >= Start && time <= End;
        }
    }
}
