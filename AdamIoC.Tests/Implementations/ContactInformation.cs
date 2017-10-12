using AdamIoC.Tests.Interfaces;

namespace AdamIoC.Tests.Implementations
{
    public class ContactInformation : IContactInformation
    {        
        public string CorporatePhoneNumber { get; set; }
        public string CustomerServicePhoneNumber { get; set; }
    }
}
