using congestion.calculator.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.TaxCalculators
{
    public interface ICongestionTaxCalculator
    {
        decimal GetTax(IVehicle vehicle, DateTime[] dates);
    }
}
