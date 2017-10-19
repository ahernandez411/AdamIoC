using System;
using System.Collections.Generic;
using System.Linq;

namespace AdamIoC.InstanceManagement
{
    public class LifecycleInstanceManagerFactory
    {
        private Dictionary<LifecycleType, Lazy<ILifeCycleInstanceManager>> managers = new Dictionary<LifecycleType, Lazy<ILifeCycleInstanceManager>>();

        public ILifeCycleInstanceManager GetLifecycleInstanceManager<TInterface>(Dictionary<Type, Lazy<RegistrationInfoModel>> registrations)
        {
            var interfaceType = typeof(TInterface);
            if (!registrations.ContainsKey(interfaceType))
            {
                throw new NotRegisteredException(interfaceType);
            }
            var lifecycle = existingRegistration.Lifecycle;
            if (managers.ContainsKey(lifecycle))
            {
                return managers[lifecycle].Value;
            }
            switch (lifecycle)
            {
                case LifecycleType.Singleton:
                    managers[lifecycle] = new Lazy<ILifeCycleInstanceManager>(() => new SingletonLifecycleInstanceManager(registrations));
                    break;
                case LifecycleType.Transient:
                    managers[lifecycle] = new Lazy<ILifeCycleInstanceManager>(() => new TransientLifecycleInstanceManager(registrations));
                    break;
                default:
                    throw new NotRegisteredException("Unsupported LifeCycleType");
            }
            return managers[lifecycle].Value;
        }
    }
}
