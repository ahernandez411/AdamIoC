using AdamIoC.Tests.Enums;
using AdamIoC.Tests.Interfaces;

namespace AdamIoC.Tests.Implementations
{
    public class Man : IHuman
    {
        public GenderType Gender => GenderType.Male;
    }
}
