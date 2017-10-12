using AdamIoC.Tests.Interfaces;
using System;

namespace AdamIoC.Tests.Implementations
{
    public class Location : ILocation
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
    }
}
