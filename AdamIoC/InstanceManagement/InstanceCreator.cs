using System;
using System.Collections.Generic;
using System.Linq;

namespace AdamIoC.InstanceManagement
{
    public class InstanceCreator : IInstanceCreator
    {
        public TInterface GetInstance<TInterface>(List<RegistrationInfoModel> registrations)
        {
            var interfaceType = typeof(TInterface);
            RegistrationInfoModel registration = FindRegistrationInfoModel(registrations, interfaceType);
            var constructor = registration.Implementation.GetConstructors().First();

            var parameters = constructor.GetParameters();

            if (!parameters.Any())
            {
                return (TInterface)CreateInstance(registration.Implementation);
            }
            else
            {
                var instances = new List<object>();
                GatherConstructorParameterInstances(registrations, instances, parameters);
                return (TInterface)CreateInstance(registration.Implementation, instances.ToArray());
            }
        }

        private void GatherConstructorParameterInstances(List<RegistrationInfoModel> registrations, List<object> instances, System.Reflection.ParameterInfo[] parameters)
        {            
            foreach (var parameter in parameters)
            {
                var registrationForParameter = FindRegistrationInfoModel(registrations, parameter.ParameterType);
                var parameterConstructor = registrationForParameter.Implementation.GetConstructors().First();
                var parameterConstructorArguments = parameterConstructor.GetParameters();
                if (parameterConstructorArguments.Any())
                {
                    foreach (var parameterConstructorArgument in parameterConstructorArguments)
                    {
                        var parameterConstructorInstances = new List<object>();
                        GatherConstructorParameterInstances(registrations, parameterConstructorInstances, parameterConstructorArguments);
                        instances.Add(CreateInstance(registrationForParameter.Implementation, parameterConstructorInstances.ToArray()));
                    }                    
                }
                else
                {
                    instances.Add(CreateInstance(registrationForParameter.Implementation));
                }                
            }
        }

        private static RegistrationInfoModel FindRegistrationInfoModel(List<RegistrationInfoModel> registrations, Type interfaceType)
        {
            var registration = registrations.FirstOrDefault(reg => reg.Interface == interfaceType);
            if (registration == null)
            {
                throw new NotRegisteredException(interfaceType);
            }
            return registration;
        }

        private object CreateInstance(Type type, params object[] parameters)
        {
            return Activator.CreateInstance(type, parameters.Any() ? parameters : null);
        }
    }
}
