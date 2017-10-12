using AdamIoC.Models.Enums;
using AdamIoC.Models.Interfaces;

namespace AdamIoC.Models.Implementations
{
    public class Car : IVehicle
    {
        public VehicleType VehicleType => VehicleType.Car;
    }
}
