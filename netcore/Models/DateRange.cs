using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Models
{
    public class DateRange
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public DateRange(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException("End date cannot be earlier than the start date.");
            }

            StartDate = startDate.Date;
            EndDate = endDate.Date;
        }

        public bool ContainsDate(DateTime date)
        {
            return date.Date >= StartDate && date.Date <= EndDate;
        }
    }
}
