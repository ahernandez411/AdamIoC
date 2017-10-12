using System.Collections.Generic;

namespace AdamIoC.InstanceManagement
{
    public interface IInstanceCreator
    {
        TInterface GetInstance<TInterface>(List<RegistrationInfoModel> registrations);
    }
}
