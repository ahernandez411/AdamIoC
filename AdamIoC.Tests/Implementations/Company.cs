using AdamIoC.Tests.Interfaces;
using System;

namespace AdamIoC.Tests.Implementations
{
    public class Company : ICompany
    {
        private readonly IContactInformation contactInformation;
        private readonly ILocation location;

        public Company(IContactInformation contactInformation, ILocation location)
        {
            this.contactInformation = contactInformation;
            this.location = location;
        }

        public string CompanyName { get; set; }
    }
}
