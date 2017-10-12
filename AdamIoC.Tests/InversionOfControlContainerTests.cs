using AdamIoC.Tests.Implementations;
using AdamIoC.Tests.Interfaces;
using Xunit;

namespace AdamIoC.Tests
{
    public class InversionOfControlContainerTests
    {
        [Fact]
        public void RegisterMultipleAndGetInstances()
        {
            var container = new ContainerAdamIoC();

            container.RegisterImplementation<IHuman, Man>();
            container.RegisterImplementation<IVehicle, Car>();

            var vehicle = container.GetInstance<IVehicle>();
            var human = container.GetInstance<IHuman>();

            Assert.NotNull(vehicle);
            Assert.NotNull(human);
        }

        [Fact]
        public void ResolveVehicle()
        {
            var container = new ContainerAdamIoC();

            container.RegisterImplementation<IVehicle, Car>();
            var vehicle = container.GetInstance<IVehicle>();

            Assert.NotNull(vehicle);
        }

        [Fact]
        public void ShowThatHumanInstancesAreTheSame()
        {
            var container = new ContainerAdamIoC();

            container.RegisterImplementation<IHuman, Man>(ObjectLifeCycleType.Singleton);

            var human1 = container.GetInstance<IHuman>();
            var human2 = container.GetInstance<IHuman>();

            Assert.NotNull(human1);
            Assert.NotNull(human2);

            Assert.Equal(human1, human2);
        }

        [Fact]
        public void ShowThatVehicleInstancesAreNotTheSame()
        {
            var container = new ContainerAdamIoC();

            container.RegisterImplementation<IVehicle, Car>();

            var vehicle1 = container.GetInstance<IVehicle>();
            var vehicle2 = container.GetInstance<IVehicle>();

            Assert.NotNull(vehicle1);
            Assert.NotNull(vehicle2);

            Assert.NotEqual(vehicle1, vehicle2);
        }
        [Fact]
        public void TryToResolveManButShouldFail()
        {
            Assert.Throws<InformativeException>(() =>
            {
                var container = new ContainerAdamIoC();
                container.GetInstance<IHuman>();
            });
        }
    }
}
