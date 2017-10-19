using System;

namespace AdamIoC.InstanceManagement
{
    public static class InstanceCreatorFactory
    {
        public static IInstanceCreator GetInstanceCreator()
        {
            return new InstanceCreator();
        }
    }
}
