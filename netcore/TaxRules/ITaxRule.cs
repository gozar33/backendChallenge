using congestion.calculator.Models;
using congestion.calculator.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.TaxRules
{
    public interface ITaxRule
    {
        TollFeeResult GetTollFee(IVehicle vehicleType, DateTime date);
    }
}
