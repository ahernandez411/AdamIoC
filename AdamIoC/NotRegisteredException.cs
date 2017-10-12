using System;

namespace AdamIoC
{
    public class NotRegisteredException : Exception
    {
        private readonly Type interfaceType;

        public NotRegisteredException() : base()
        { }

        public NotRegisteredException(string message) : base()
        { }

        public NotRegisteredException(Type interfaceType) 
        {
            this.interfaceType = interfaceType;
        }

        public override string Message => interfaceType != null ? $"Unable to find implementation for {interfaceType.Name}" : base.Message;
    }
}
