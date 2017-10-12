using System;
using System.Collections.Generic;

namespace AdamIoC.InstanceManagement
{
    public class SingletonLifecycleInstanceManager : LifeCycleInstanceManager
    {
        private static Dictionary<Type, object> instances = new Dictionary<Type, object>();

        public SingletonLifecycleInstanceManager(List<RegistrationInfoModel> registrations) : base(registrations)
        { }

        public override ObjectLifeCycleType ObjectLifecycle => ObjectLifeCycleType.Singleton;

        public override TInterface GetInstance<TInterface>()
        {
            var interfaceType = typeof(TInterface);
            if (instances.ContainsKey(interfaceType))
            {
                return (TInterface)instances[interfaceType];
            }
            else
            {
                var instance = base.GetInstance<TInterface>();
                instances[interfaceType] = instance;
                return instance;
            }            
        }
    }
}
