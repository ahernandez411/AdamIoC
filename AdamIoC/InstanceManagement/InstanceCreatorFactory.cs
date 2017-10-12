using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
