using System;
using System.Collections.Generic;
using System.Linq;

namespace AdamIoC.InstanceManagement
{
    public class SingletonInstanceManager : IInstanceManager
    {
        private Dictionary<Type, object> instances = new Dictionary<Type, object>();
        public ObjectLifeCycleType ObjectLifecycle => ObjectLifeCycleType.Singleton;

        public IList<RegistrationInfoModel> Registrations { get; set; } = new List<RegistrationInfoModel>();
        public TInterface GetInstance<TInterface>(params object[] constructorParameters)
        {
            var interfaceType = typeof(TInterface);
            var registrationInfoModel = Registrations.FirstOrDefault(registration => registration.Interface == interfaceType);
            if (registrationInfoModel == null)
            {
                throw new KeyNotFoundException($"No implementation found for {interfaceType.Name}");
            }
            if (instances.ContainsKey(interfaceType))
            {
                return (TInterface)instances[interfaceType];
            }
            else
            {
                var @interface = Activator.CreateInstance(registrationInfoModel.Implementation, constructorParameters);
                instances[interfaceType] = @interface;

                return (TInterface)@interface;
            }
        }
    }
}
