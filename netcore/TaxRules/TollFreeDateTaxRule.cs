using congestion.calculator.Models;
using congestion.calculator.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace congestion.calculator.TaxRules
{
    public class TollFreeDateTaxRule : ITaxRule
    {
        private readonly List<DateRange> _tollFreeDates;

        public TollFreeDateTaxRule(List<DateRange> tollFreeDates)
        {
            _tollFreeDates = tollFreeDates;
        }

        public TollFeeResult GetTollFee(IVehicle vehicle, DateTime date)
        {
            var result = new TollFeeResult();
            foreach (var dateRange in _tollFreeDates)
            {
                if (dateRange.ContainsDate(date))
                {
                    result.IsTaxable = false;
                    return result;
                }
            }

            result.IsTaxable = true;
            return result;
        }
    }
}
