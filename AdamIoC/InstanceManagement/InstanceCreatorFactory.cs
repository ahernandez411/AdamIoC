using System;

namespace AdamIoC.InstanceManagement
{
    public class InstanceCreatorFactory
    {
        private Lazy<IInstanceCreator> instanceCreator;

        public IInstanceCreator GetInstanceCreator()
        {
            if (instanceCreator == null)
            {
                instanceCreator = new Lazy<IInstanceCreator>(() => new InstanceCreator());
            }
            return instanceCreator.Value;
        }
    }
}
