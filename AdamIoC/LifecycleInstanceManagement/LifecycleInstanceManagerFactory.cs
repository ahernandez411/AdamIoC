using System.Collections.Generic;
using System.Linq;

namespace AdamIoC.InstanceManagement
{
    public static class LifecycleInstanceManagerFactory
    {
        public static ILifeCycleInstanceManager GetLifecycleInstanceManager<TInterface>(List<RegistrationInfoModel> registrations)
        {
            var interfaceType = typeof(TInterface);
            var existingRegistration = registrations.FirstOrDefault(reg => reg.Interface == interfaceType);
            if (existingRegistration == null)
            {
                throw new InformativeException(interfaceType);
            }

            switch (existingRegistration.ObjectLifecycle)
            {
                case ObjectLifeCycleType.Singleton:
                    return new SingletonLifecycleInstanceManager(registrations);
                case ObjectLifeCycleType.Transient:
                    return new TransientLifecycleInstanceManager(registrations);
                default:
                    throw new InformativeException("Unsupported ObjectLifeCycleType");
            }
        }
    }
}
