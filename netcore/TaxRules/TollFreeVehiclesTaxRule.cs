using congestion.calculator.Models;
using congestion.calculator.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace congestion.calculator.TaxRules
{
    public class TollFreeVehiclesTaxRule : ITaxRule
    {
        private readonly List<IVehicle> _tollFreeVehicles;

        public TollFreeVehiclesTaxRule(List<IVehicle> tollFreeVehicles)
        {
            _tollFreeVehicles = tollFreeVehicles;
        }

        public TollFeeResult GetTollFee(IVehicle vehicle, DateTime date)
        {
            var result = new TollFeeResult();
            if (!_tollFreeVehicles.Contains(vehicle))
                result.IsTaxable = true;

            return result;
        }
    }
}
