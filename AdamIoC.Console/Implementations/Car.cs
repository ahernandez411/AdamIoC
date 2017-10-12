using AdamIoC.Console.Interfaces;

namespace AdamIoC.Console.Implementations
{
    public class Car : IVehicle
    {
        public VehicleType VehicleType => VehicleType.Car;
    }
}
