using AdamIoC.Tests.Interfaces;
using System;

namespace AdamIoC.Tests.Implementations
{
    public class ContactInformation : IContactInformation
    {
        public string CustomerServicePhoneNumber { get; set; }
        public string CorporatePhoneNumber { get; set; }
    }
}
