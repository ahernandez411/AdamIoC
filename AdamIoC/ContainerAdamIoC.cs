using AdamIoC.InstanceManagement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdamIoC
{
    public class ContainerAdamIoC
    {
        private readonly LifecycleInstanceManagerFactory lifecycleInstanceManagerFactory;
        private Dictionary<Type, Lazy<RegistrationInfoModel>> registrations = new Dictionary<Type, Lazy<RegistrationInfoModel>>();

        public ContainerAdamIoC()
        {
            lifecycleInstanceManagerFactory = new LifecycleInstanceManagerFactory();
        }

        public TInterface GetInstance<TInterface>()
        {
            var lifecycleInstanceManager = lifecycleInstanceManagerFactory.GetLifecycleInstanceManager<TInterface>(registrations);
            return lifecycleInstanceManager.GetInstance<TInterface>();
        }

        public void RegisterImplementation<TInterface, TImplementation>(LifecycleType objectLifecycleType = LifecycleType.Transient) where TImplementation : TInterface
        {            
            var interfaceType = typeof(TInterface);
            if (!registrations.ContainsKey(interfaceType))
            {
                registrations.Add(interfaceType, new Lazy<RegistrationInfoModel>(
                    () =>
                    {
                        return new RegistrationInfoModel
                        {
                            Implementation = typeof(TImplementation),
                            Interface = typeof(TInterface),
                            ObjectLifecycle = objectLifecycleType
                        };
                    }, isThreadSafe: true)
                );
            }
            else
            {
                var existingRegistration = registrations[interfaceType].Value;
                existingRegistration.Implementation = typeof(TImplementation);
                existingRegistration.ObjectLifecycle = objectLifecycleType;
            }
        }
    }
}
