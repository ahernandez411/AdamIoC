using AdamIoC.InstanceManagement;
using System.Collections.Generic;
using System.Linq;

namespace AdamIoC
{
    public class ContainerAdamIoC
    {
        private Dictionary<ObjectLifeCycleType, IInstanceManager> instanceManagers = new Dictionary<ObjectLifeCycleType, IInstanceManager>();

        public TInterface GetInstance<TInterface>()
        {
            var interfaceType = typeof(TInterface);
            var allInstanceManagers = instanceManagers.Values.ToList();

            var instanceManager = allInstanceManagers.FirstOrDefault(manager => manager.Registrations.FirstOrDefault(registration => registration.Interface == interfaceType) != null);            
            if (instanceManager == null)
            {
                throw new InformativeException(typeof(TInterface));
            }
            return instanceManager.GetInstance<TInterface>();
        }

        public void RegisterImplementation<TInterface, TImplementation>(ObjectLifeCycleType objectLifecycleType = ObjectLifeCycleType.Transient) where TImplementation : TInterface
        {
            var interfaceType = typeof(TInterface);
            var registrationInfoModel = new RegistrationInfoModel
            {
                Implementation = typeof(TImplementation),
                Interface = typeof(TInterface)
            };
            if (!instanceManagers.ContainsKey(objectLifecycleType))
            {
                var instanceManager = InstanceManagerFactory.GetInstanceManager(objectLifecycleType);
                instanceManager.Registrations.Add(registrationInfoModel);
                instanceManagers[objectLifecycleType] = instanceManager;
            }
            else
            {
                var instanceManager = instanceManagers[objectLifecycleType];
                if (instanceManager.Registrations.Any(registration => registration.Interface == interfaceType))
                {
                    // already registered
                    return;
                }
                instanceManager.Registrations.Add(registrationInfoModel);
            }
        }
    }
}
