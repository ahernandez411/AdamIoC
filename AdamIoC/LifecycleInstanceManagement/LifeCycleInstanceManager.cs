using System.Collections.Generic;

namespace AdamIoC.InstanceManagement
{
    public abstract class LifeCycleInstanceManager : ILifeCycleInstanceManager
    {
        private readonly List<RegistrationInfoModel> registrations;

        public LifeCycleInstanceManager(List<RegistrationInfoModel> registrations)
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
