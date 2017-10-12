using AdamIoC.Tests.Interfaces;
using System;

namespace AdamIoC.Tests.Implementations
{
    public class Location : ILocation
    {
        public string Street { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string City { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PostalCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string State { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
