using System;
using System.Collections.Generic;

namespace AdamIoC.InstanceManagement
{
    public abstract class LifeCycleInstanceManager : ILifeCycleInstanceManager
    {
        private readonly Dictionary<Type, Lazy<RegistrationInfoModel>> registrations;

        public LifeCycleInstanceManager(Dictionary<Type, Lazy<RegistrationInfoModel>> registrations)
        {
            this.registrations = registrations;
        }

        public abstract LifecycleType ObjectLifecycle { get; }

        public virtual TInterface GetInstance<TInterface>()
        {
            var instanceCreator = InstanceCreatorFactory.GetInstanceCreator();
            return instanceCreator.GetInstance<TInterface>(registrations);
        }
    }
}
