using AdamIoC.Tests.Interfaces;

namespace AdamIoC.Tests.Implementations
{
    public class CompanyContactPerson : IContactInformation
    {
        public CompanyContactPerson(IHuman contactPerson, ILocation location)
        {
            ContactPerson = contactPerson;
        }

        public ICompany Company { get; set; }
        public IHuman ContactPerson { get; set; }
        public string CorporatePhoneNumber { get; set; }
        public string CustomerServicePhoneNumber { get; set; }
        public ILocation Location { get; set; }
    }
}
