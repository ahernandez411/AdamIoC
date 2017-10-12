using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdamIoC.InstanceManagement
{
    public interface IInstanceManager
    {
        ObjectLifeCycleType ObjectLifecycle { get; }
        IList<RegistrationInfoModel> Registrations { get; set; }
        TInterface GetInstance<TInterface>(params object[] constructorParameters);
    }
}
