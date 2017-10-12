using AdamIoC.Tests.Interfaces;
using System;

namespace AdamIoC.Tests.Implementations
{
    public class ContactInformation : IContactInformation
    {
        public string CustomerServicePhoneNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CorporatePhoneNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
