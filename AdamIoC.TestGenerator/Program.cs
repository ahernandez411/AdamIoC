using System;
using System.Configuration;
using System.IO;
using System.Text;
using static AdamIoC.TestGenerator.CodeTemplates;

namespace AdamIoC.TestGenerator
{
    class Program
    {
        private const string NumberToGenerate = "NumberToGenerate";
        private const string ReplaceSingletons = "[[Singletons]]";
        private const string ReplaceTransients = "[[Transients]]";
        private const string ReplaceWithGeneratedCode = "[[GeneratedCode]]";
        private static readonly string BasePath = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "") + "GeneratedModels\\";
        private static readonly int interfaceClassPairsToGenerate = int.Parse(ConfigurationManager.AppSettings[NumberToGenerate]);        
        private static readonly string PathFinalTemplate = $"{BasePath}GeneratedStuff.txt";
        private static readonly string PathGeneratedRegistrations = $"{BasePath}GeneratedRegistrations.txt";
        private static readonly string PathLargeResolverTestsCs = $"{BasePath}LargeResolverTests.cs";
        private static readonly string PathLargeResolverTestsTxt = $"{BasePath}LargeResolverTests.txt";
        private static readonly string PathToFinalCode = $"{BasePath}InterfacesAndClasses.cs";

        static void Main(string[] args)
        {
            var classBuilder = new StringBuilder();
            var interfaceBuilder = new StringBuilder();
            var registrationsSingleton = new StringBuilder();
            var registrationsTransient = new StringBuilder();

            for (var index = 0; index < interfaceClassPairsToGenerate; index++)
            {
                var current = index;
                var next = current + 1;
                if (index == 0)
                {
                    interfaceBuilder.Append(CreateInterface(current));
                    registrationsSingleton.Append(CreateContainer());
                    registrationsTransient.Append(CreateContainer());
                }

                if (index == (interfaceClassPairsToGenerate - 1))
                {
                    classBuilder.Append(CreateClass(current));
                }
                else
                {
                    interfaceBuilder.Append(CreateInterface(next));
                    classBuilder.Append(CreateClass(current, next));
                }

                registrationsSingleton.Append(CreateContainerRegistration(current, true));
                registrationsTransient.Append(CreateContainerRegistration(current, false));
            }

            SaveInterfacesAndClasses(classBuilder, interfaceBuilder);
            SaveXUnitTests(registrationsSingleton, registrationsTransient);
        }

        private static void SaveInterfacesAndClasses(StringBuilder classBuilder, StringBuilder interfaceBuilder)
        {
            var finalCode = File.ReadAllText(PathFinalTemplate);
            var codeBuilder = new StringBuilder();
            codeBuilder.Append(interfaceBuilder);
            codeBuilder.AppendLine();
            codeBuilder.Append(classBuilder);

            finalCode = finalCode.Replace(ReplaceWithGeneratedCode, codeBuilder.ToString());
            File.WriteAllText(PathToFinalCode, finalCode);
        }

        private static void SaveXUnitTests(StringBuilder registrationsSingleton, StringBuilder registrationsTransient)
        {
            var xUnitTests = File.ReadAllText(PathLargeResolverTestsTxt);

            var codeSingletons = new StringBuilder();
            codeSingletons.AppendLine("#region Singletons");
            codeSingletons.Append(registrationsSingleton);
            codeSingletons.AppendLine();
            codeSingletons.AppendLine();
            codeSingletons.AppendLine("#endregion Singletons");
            codeSingletons.AppendLine(CreateGetInstance(0));

            xUnitTests = xUnitTests.Replace(ReplaceSingletons, codeSingletons.ToString());

            var codeTransients = new StringBuilder();
            codeTransients.AppendLine();
            codeTransients.AppendLine("#region Transients");
            codeTransients.Append(registrationsTransient);
            codeTransients.AppendLine();
            codeTransients.AppendLine();
            codeTransients.AppendLine("#endregion Transients");
            codeTransients.AppendLine(CreateGetInstance(0));

            xUnitTests = xUnitTests.Replace(ReplaceTransients, codeTransients.ToString());

            File.WriteAllText(PathLargeResolverTestsCs, xUnitTests);
        }
    }
}
