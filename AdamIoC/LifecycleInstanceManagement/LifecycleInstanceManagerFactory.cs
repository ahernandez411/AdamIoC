using System;
using System.Collections.Generic;
using System.Linq;

namespace AdamIoC.InstanceManagement
{
    public static class LifecycleInstanceManagerFactory
    {
        public static ILifeCycleInstanceManager GetLifecycleInstanceManager<TInterface>(Dictionary<Type, Lazy<RegistrationInfoModel>> registrations)
        {
            var interfaceType = typeof(TInterface);
            if (!registrations.ContainsKey(interfaceType))
            {
                throw new NotRegisteredException(interfaceType);
            }
            var existingRegistration = registrations[interfaceType].Value;
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
