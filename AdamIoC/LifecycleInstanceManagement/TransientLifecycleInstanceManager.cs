using System;
using System.Collections.Generic;
using System.Linq;

namespace AdamIoC.InstanceManagement
{
    public class TransientLifecycleInstanceManager : LifeCycleInstanceManager
    {
        public TransientLifecycleInstanceManager(Dictionary<Type, Lazy<RegistrationInfoModel>> registrations) : base(registrations)
        { }

        public override LifecycleType ObjectLifecycle => LifecycleType.Transient;
    }
}
