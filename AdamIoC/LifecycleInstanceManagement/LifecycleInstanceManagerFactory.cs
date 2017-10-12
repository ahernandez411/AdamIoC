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
                throw new NotRegisteredException(interfaceType);
            }

            switch (existingRegistration.ObjectLifecycle)
            {
                case LifecycleType.Singleton:
                    return new SingletonLifecycleInstanceManager(registrations);
                case LifecycleType.Transient:
                    return new TransientLifecycleInstanceManager(registrations);
                default:
                    throw new NotRegisteredException("Unsupported LifeCycleType");
            }
        }
    }
}
