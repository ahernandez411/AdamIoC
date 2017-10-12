using System;
using System.Collections.Generic;
using System.Linq;

namespace AdamIoC.InstanceManagement
{
    public class InstanceCreator : IInstanceCreator
    {
        public TInterface GetInstance<TInterface>(List<RegistrationInfoModel> registrations)
        {
            var interfaceType = typeof(TInterface);
            var registration = registrations.FirstOrDefault(reg => reg.Interface == interfaceType);
            if (registration == null)
            {
                throw new InformativeException(interfaceType);
            }
            return (TInterface)Activator.CreateInstance(registration.Implementation);
        }
    }
}
