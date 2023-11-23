using System;
using System.Collections.Generic;
using System.Text;

namespace congestion.calculator.Vehicles
{
    public class Foreign : IVehicle
    {
        public VehicleType GetVehicleType()
        {
            return VehicleType.Foreign;
        }
    }
}
