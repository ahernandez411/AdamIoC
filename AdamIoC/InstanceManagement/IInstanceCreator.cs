using System;
using System.Collections.Generic;

namespace AdamIoC.InstanceManagement
{
    public interface IInstanceCreator
    {
        TInterface GetInstance<TInterface>(Dictionary<Type, Lazy<RegistrationInfoModel>> registrations);
    }
}
