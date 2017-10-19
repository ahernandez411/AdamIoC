using System;
using System.Collections.Generic;

namespace AdamIoC.InstanceManagement
{
    public abstract class LifeCycleInstanceManager : ILifeCycleInstanceManager
    {
        private readonly Dictionary<Type, Lazy<RegistrationInfoModel>> registrations;
        private readonly InstanceCreatorFactory instanceCreatorFactory;

        public LifeCycleInstanceManager(Dictionary<Type, Lazy<RegistrationInfoModel>> registrations)
        {
            this.registrations = registrations;
            instanceCreatorFactory = new InstanceCreatorFactory();
        }

        public abstract LifecycleType ObjectLifecycle { get; }

        public virtual TInterface GetInstance<TInterface>()
        {
            var instanceCreator = instanceCreatorFactory.GetInstanceCreator();
            return instanceCreator.GetInstance<TInterface>(registrations);
        }
    }
}
