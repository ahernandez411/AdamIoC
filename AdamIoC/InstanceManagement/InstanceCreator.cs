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
                foreach (var parameter in parameters)
                {
                    var registrationForParameter = FindRegistrationInfoModel(registrations, parameter.ParameterType);
                    instances.Add(CreateInstance(registrationForParameter.Implementation));
                }
                return (TInterface)CreateInstance(registration.Implementation, instances.ToArray());
            }
        }

        private static RegistrationInfoModel FindRegistrationInfoModel(List<RegistrationInfoModel> registrations, Type interfaceType)
        {
            var registration = registrations.FirstOrDefault(reg => reg.Interface == interfaceType);
            if (registration == null)
            {
                throw new InformativeException(interfaceType);
            }
            return registration;
        }

        private object CreateInstance(Type type, params object[] parameters)
        {
            return Activator.CreateInstance(type, parameters.Any() ? parameters : null);
        }
    }
}
