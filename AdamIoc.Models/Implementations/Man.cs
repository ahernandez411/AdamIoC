using AdamIoC.Models.Enums;
using AdamIoC.Models.Interfaces;

namespace AdamIoC.Models.Implementations
{
    public class Man : IHuman
    {
        public GenderType Gender => GenderType.Male;
    }
}
