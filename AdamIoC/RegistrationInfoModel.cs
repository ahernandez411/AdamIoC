using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdamIoC
{
    public class RegistrationInfoModel
    {
        public Type Implementation { get; set; }
        public Type Interface { get; set; }
        public ObjectLifeCycleType ObjectLifecycle { get; set; }
    }
}
