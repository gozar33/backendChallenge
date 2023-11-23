using congestion.calculator.TaxRules;
using congestion.calculator.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace congestion.calculator.TaxCalculators
{
    internal class CongestionTaxCalculator : ICongestionTaxCalculator
    {
        private readonly List<ITaxRule> _taxRules;
        private decimal _maxTotalTaxPerDay = 60;
        private int _allowedMinutesForPassesSeveralTollingStations = 60;

        public CongestionTaxCalculator(List<ITaxRule> taxRules)
        {
            _taxRules = taxRules;
        }

        public decimal GetTax(IVehicle vehicle, DateTime[] dates)
        {
            decimal totalTax = 0;

            Array.Sort(dates);
            var groupedByDay = dates.GroupBy(x => x.Date);

            foreach (var dateGroup in groupedByDay)
            {
                decimal taxPerDay = 0;
                decimal maxFeeIn60MinutesInterval = 0;
                var datesInSameDay = dateGroup.OrderBy(x => x);
                var previousDateTime = datesInSameDay.First();

                foreach (var currentDateTime in datesInSameDay)
                {
                    if (currentDateTime - previousDateTime <= TimeSpan.FromMinutes(_allowedMinutesForPassesSeveralTollingStations))
                    {
                        var feeForPreviousDateTime = GetTollFee(vehicle, previousDateTime);
                        var feeForCurrentDateTime = GetTollFee(vehicle, currentDateTime);

                        var maxFee = Math.Max(feeForPreviousDateTime, feeForCurrentDateTime);
                        maxFeeIn60MinutesInterval = Math.Max(maxFeeIn60MinutesInterval, maxFee);
                    }
                    else
                    {
                        taxPerDay += GetTollFee(vehicle, currentDateTime);
                        taxPerDay += maxFeeIn60MinutesInterval;
                        maxFeeIn60MinutesInterval = 0;
                    }

                    previousDateTime = currentDateTime;
                }

                taxPerDay += maxFeeIn60MinutesInterval;
                totalTax += Math.Min(taxPerDay, _maxTotalTaxPerDay);
            }

            return totalTax;
        }

        private decimal GetTollFee(IVehicle vehicle, DateTime date)
        {
            decimal tollFee = 0;
            foreach (ITaxRule taxRule in _taxRules)
            {
                var tollFeeResult = taxRule.GetTollFee(vehicle, date);
                if (!tollFeeResult.IsTaxable)
                    return tollFeeResult.TollFee;
                tollFee += tollFeeResult.TollFee;
            }
            return tollFee;
        }
    }
}
