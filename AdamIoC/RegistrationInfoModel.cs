using System;

namespace AdamIoC
{
    public class RegistrationInfoModel
    {
        public Type Implementation { get; set; }
        public Type Interface { get; set; }
        public LifecycleType ObjectLifecycle { get; set; }

        public override string ToString()
        {
            return $"RegisterImplementation<{Interface.Name}, {Implementation.Name}>(LifecycleType.{ObjectLifecycle})";
        }
    }
}
