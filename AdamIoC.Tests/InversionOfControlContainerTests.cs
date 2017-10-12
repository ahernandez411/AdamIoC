using AdamIoC.Models.Implementations;
using AdamIoC.Models.Interfaces;
using System;
using Xunit;

namespace AdamIoC.Tests
{
    public class InversionOfControlContainerTests
    {
        [Fact]
        public void ResolveCar()
        {
            InversionOfControlContainer.RegisterImplementation<IVehicle, Car>();
            var vehicle = InversionOfControlContainer.GetInstance<IVehicle>();

            Assert.NotNull(vehicle);
        }

        [Fact]
        public void ShowThatCarInstancesAreNotTheSame()
        {
            InversionOfControlContainer.RegisterImplementation<IVehicle, Car>();

            var vehicle1 = InversionOfControlContainer.GetInstance<IVehicle>();
            var vehicle2 = InversionOfControlContainer.GetInstance<IVehicle>();

            Assert.NotNull(vehicle1);
            Assert.NotNull(vehicle2);

            Assert.NotEqual(vehicle1, vehicle2);
        }

        [Fact]
        public void ShowThatManInstancesAreTheSame()
        {
            InversionOfControlContainer.RegisterImplementation<IHuman, Man>(ObjectLifeCycleType.Singleton);

            var man1 = InversionOfControlContainer.GetInstance<IHuman>();
            var man2 = InversionOfControlContainer.GetInstance<IHuman>();

            Assert.NotNull(man1);
            Assert.NotNull(man2);

            Assert.Equal(man1, man2);
        }


        [Fact]
        public void TryToResolveManButShouldFail()
        {
            Assert.Throws<Exception>(() => 
            {
                InversionOfControlContainer.GetInstance<IHuman>();
            });
        }
    }
}
