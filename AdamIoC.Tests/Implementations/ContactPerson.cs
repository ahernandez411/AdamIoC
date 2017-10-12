using AdamIoC.Tests.Enums;
using AdamIoC.Tests.Interfaces;

namespace AdamIoC.Tests.Implementations
{
    public class ContactPerson : IHuman
    {
        public ContactPerson(IName name)
        {
            Name = name;
        }
        public GenderType Gender => GenderType.Female;
        public IName Name { get; set; }
    }
}
