using System;
using System.Linq;
using System.Reflection;

namespace AdamIoC
{
    public static class Extensions
    {
        public static ConstructorInfo SmallestConstructor(this Type type)
        {
            return type.GetConstructors()
                    .OrderBy(item => item.GetParameters().Length)
                    .First()
                    ;
        }
    }
}
