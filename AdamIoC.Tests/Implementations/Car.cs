using AdamIoC.Tests.Enums;
using AdamIoC.Tests.Interfaces;

namespace AdamIoC.Tests.Implementations
{
    public class Car : IVehicle
    {
        public VehicleType VehicleType => VehicleType.Car;
    }
}
