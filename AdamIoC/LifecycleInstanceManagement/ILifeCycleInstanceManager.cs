namespace AdamIoC.InstanceManagement
{
    public interface ILifeCycleInstanceManager
    {
        ObjectLifeCycleType ObjectLifecycle { get; }
        TInterface GetInstance<TInterface>();
    }
}
