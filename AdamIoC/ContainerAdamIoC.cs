using AdamIoC.InstanceManagement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdamIoC
{
    public class ContainerAdamIoC
    {
        private Dictionary<ObjectLifeCycleType, List<IInstanceManager>> instanceManagers = new Dictionary<ObjectLifeCycleType, List<IInstanceManager>>();

        public TInterface GetInstance<TInterface>(params object[] constructorParameters)
        {
            var allInstanceManagers = instanceManagers.Values.SelectMany(item => item).ToList();
            var instanceManager = allInstanceManagers.FirstOrDefault(
                manager => manager.Registrations.FirstOrDefault(
                    registration => registration.Interface == typeof(TInterface)) != null
            );
            if (instanceManager == null)
            {
                throw new InformativeException(typeof(TInterface));
            }
            return instanceManager.GetInstance<TInterface>(constructorParameters);
        }

        public void RegisterImplementation<TInterface, TImplementation>(ObjectLifeCycleType objectLifecycleType = ObjectLifeCycleType.Transient) where TImplementation : TInterface
        {
            var interfaceType = typeof(TInterface);
            var instanceManager = InstanceManagerFactory.GetInstanceManager(objectLifecycleType);
            instanceManager.Registrations.Add(new RegistrationInfoModel
            {
                Implementation = typeof(TImplementation),
                Interface = typeof(TInterface)
            });
            if (!instanceManagers.ContainsKey(objectLifecycleType))
            {
                instanceManagers[objectLifecycleType] = new List<IInstanceManager>();
                instanceManagers[objectLifecycleType].Add(instanceManager);
            }
            else
            {
                var lifeCycleInstances = instanceManagers[objectLifecycleType];
                if (lifeCycleInstances.Any(manager => manager.Registrations.Any(registration => registration.Interface == interfaceType)))
                {
                    // already registered
                    return;
                }
                lifeCycleInstances.Add(instanceManager);
            }
        }
    }
}
