using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdamIoC.InstanceManagement
{
    public static class InstanceManagerFactory
    {
        public static IInstanceManager GetInstanceManager(ObjectLifeCycleType objectLifecycleType)
        {
            switch (objectLifecycleType)
            {
                case ObjectLifeCycleType.Singleton:
                    return new SingletonInstanceManager();
                case ObjectLifeCycleType.Transient:
                    return new TransientInstanceManager();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
