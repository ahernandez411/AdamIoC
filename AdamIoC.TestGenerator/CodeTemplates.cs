using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdamIoC.TestGenerator
{
    public static class CodeTemplates
    {
        private const string Class = @"
    public class MyClass{0} : IMyInterface{0}
    {{
        private IMyInterface{1} myInterface{1};

        public MyClass{0}(IMyInterface{1} myInterface{1})
        {{
            this.myInterface{1} = myInterface{1};
        }}

        public string Name{1}
        {{
            get {{ return myInterface{1}.Name{1}; }}
        }}

        public string Name{0} {{ get; set; }} = ""Name{0}"";
    }}";

        private const string ClassSmall = @"
    public class MyClass{0} : IMyInterface{0}
    {{
        public string Name{0} {{ get; set; }} = ""Name{0}"";
    }}";

        private const string Interface = @"
    public interface IMyInterface{0}
    {{
        string Name{0} {{ get; set; }}
    }}";

        public static string CreateContainer()
        {
            return @"
            var container = new ContainerAdamIoC();";
        }

        public static string CreateContainerRegistration(int index, bool isSingleton)
        {
            var lifecycle = isSingleton ? "LifecycleType.Singleton" : "LifecycleType.Transient";
            return $@"
            container.RegisterImplementation<IMyInterface{index}, MyClass{index}>({lifecycle});";
        }

        public static string CreateGetInstance(int index)
        {
            return $@"
            var instance = container.GetInstance<IMyInterface{index}>();

            Assert.NotNull(instance);";
        }


        public static string CreateClass(int index)
        {
            return string.Format(ClassSmall, index);
        }

        public static string CreateClass(int index1, int index2)
        {
            return string.Format(Class, index1, index2);
        }

        public static string CreateInterface(int index)
        {
            return string.Format(Interface, index);
        }
    }
}
