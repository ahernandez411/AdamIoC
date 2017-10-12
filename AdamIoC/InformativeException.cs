using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdamIoC
{
    public class InformativeException : Exception
    {
        private readonly Type interfaceType;
        public InformativeException() : base()
        { }

        public InformativeException(string message) : base()
        { }

        public InformativeException(Type interfaceType) 
        {
            this.interfaceType = interfaceType;
        }

        public override string Message => interfaceType != null ? $"Unable to find implementation for {interfaceType.Name}" : base.Message;
    }
}
