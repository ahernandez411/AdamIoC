using AdamIoC.InstanceManagement;
using System.Collections.Generic;
using System.Linq;

namespace AdamIoC
{
    public class ContainerAdamIoC
    {
        private List<RegistrationInfoModel> registrations = new List<RegistrationInfoModel>();

        public TInterface GetInstance<TInterface>()
        {
            var lifecycleInstanceManager = LifecycleInstanceManagerFactory.GetLifecycleInstanceManager<TInterface>(registrations);
            return lifecycleInstanceManager.GetInstance<TInterface>();
        }

        public void RegisterImplementation<TInterface, TImplementation>(LifecycleType objectLifecycleType = LifecycleType.Transient) where TImplementation : TInterface
        {            
            var interfaceType = typeof(TInterface);
            var existingRegistration = registrations.FirstOrDefault(registration => registration.Interface == interfaceType);

            if (existingRegistration != null)
            {
                existingRegistration.Implementation = typeof(TImplementation);
                existingRegistration.ObjectLifecycle = objectLifecycleType;
            }
            else
            {
                registrations.Add(new RegistrationInfoModel
                {
                    Implementation = typeof(TImplementation),
                    Interface = typeof(TInterface),
                    ObjectLifecycle = objectLifecycleType
                });
            }
        }
    }
}
