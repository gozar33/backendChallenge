using congestion.calculator.TaxRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.TaxCalculators
{
    public class TaxClaculatorFactory
    {
        public ICongestionTaxCalculator GetCityTaxCalculator(string cityName, List<ITaxRule> taxRules)
        {
            if (cityName == "Gothenburg")
            {
                return new CongestionTaxCalculator(taxRules);
            }
            // Add more cities Congestion Tax Calculator here if calculate method is different
            else
            {
                //return default Congestion Tax Calculator
                return new CongestionTaxCalculator(taxRules);
            }

        }
    }
}
