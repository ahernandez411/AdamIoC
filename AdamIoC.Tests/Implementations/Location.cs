using AdamIoC.Tests.Interfaces;

namespace AdamIoC.Tests.Implementations
{
    public class Location : ILocation
    {
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
    }
}
