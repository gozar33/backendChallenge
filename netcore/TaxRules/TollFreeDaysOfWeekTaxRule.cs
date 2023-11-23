using congestion.calculator.Models;
using congestion.calculator.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace congestion.calculator.TaxRules
{
    public class TollFreeDaysOfWeekTaxRule : ITaxRule
    {
        private readonly List<DayOfWeek> _tollFreeDaysOfWeek;

        public TollFreeDaysOfWeekTaxRule(List<DayOfWeek> tollFreeDaysOfWeek)
        {
            _tollFreeDaysOfWeek = tollFreeDaysOfWeek;
        }

        public TollFeeResult GetTollFee(IVehicle vehicle, DateTime date)
        {
            var result = new TollFeeResult();
            if (!_tollFreeDaysOfWeek.Contains(date.DayOfWeek))
                result.IsTaxable = true;

            return result;
        }
    }
}

