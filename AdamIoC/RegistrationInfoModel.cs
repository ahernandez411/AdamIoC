using System;

namespace AdamIoC
{
    public class RegistrationInfoModel
    {
        public Type Implementation { get; set; }
        public Type Interface { get; set; }
        public ObjectLifeCycleType ObjectLifecycle { get; set; }
    }
}
