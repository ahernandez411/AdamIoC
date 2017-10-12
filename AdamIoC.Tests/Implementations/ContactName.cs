using AdamIoC.Tests.Interfaces;

namespace AdamIoC.Tests.Implementations
{
    public class ContactName : IName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
