using System;
using System.Collections.Generic;
using System.Linq;

namespace AdamIoC.InstanceManagement
{
    public class TransientInstanceManager : IInstanceManager
    {
        public ObjectLifeCycleType ObjectLifecycle => ObjectLifeCycleType.Transient;

        public IList<RegistrationInfoModel> Registrations { get; set; } = new List<RegistrationInfoModel>();

        public TInterface GetInstance<TInterface>()
        {
            var interfaceType = typeof(TInterface);
            var registrationInfoModel = Registrations.FirstOrDefault(registration => registration.Interface == interfaceType);
            if (registrationInfoModel == null)
            {
                throw new InformativeException(interfaceType);
            }
            return (TInterface)Activator.CreateInstance(registrationInfoModel.Implementation);
        }
    }
}
