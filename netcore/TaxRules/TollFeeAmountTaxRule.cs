using congestion.calculator.Models;
using congestion.calculator.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace congestion.calculator.TaxRules
{
    public class TollFeeAmountTaxRule : ITaxRule
    {
        private readonly Dictionary<TimeRange, decimal> _tollFeeAmounts;
        public TollFeeAmountTaxRule(Dictionary<TimeRange, decimal> tollFeeAmounts)
        {
            _tollFeeAmounts = tollFeeAmounts;
        }

        public TollFeeResult GetTollFee(IVehicle vehicle, DateTime date)
        {
            var result = new TollFeeResult();
            foreach (var keyValuePair in _tollFeeAmounts)
            {
                if (keyValuePair.Key.Contains(date.TimeOfDay))
                {
                    result.TollFee = keyValuePair.Value;
                    result.IsTaxable = true;
                    break;
                }
            }
            return result;
        }
    }
}