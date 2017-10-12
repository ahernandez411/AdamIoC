namespace AdamIoC.InstanceManagement
{
    public interface ILifeCycleInstanceManager
    {
        LifecycleType ObjectLifecycle { get; }
        TInterface GetInstance<TInterface>();
    }
}
