using System;
using System.Collections.Generic;

namespace AdamIoC.InstanceManagement
{
    public class SingletonLifecycleInstanceManager : LifeCycleInstanceManager
    {
        private static Dictionary<Type, Lazy<object>> instances = new Dictionary<Type, Lazy<object>>();

        public SingletonLifecycleInstanceManager(Dictionary<Type, Lazy<RegistrationInfoModel>> registrations) : base(registrations)
        { }

        public override LifecycleType ObjectLifecycle => LifecycleType.Singleton;

        public override TInterface GetInstance<TInterface>()
        {
            var interfaceType = typeof(TInterface);
            if (!instances.ContainsKey(interfaceType))
            {
                var instance = base.GetInstance<TInterface>();
                instances.Add(interfaceType, new Lazy<object>(() => instance, isThreadSafe: true));
            }
            return (TInterface)instances[interfaceType].Value;
        }
    }
}
