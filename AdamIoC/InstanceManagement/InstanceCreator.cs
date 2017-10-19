using System;
using System.Collections.Generic;
using System.Linq;

namespace AdamIoC.InstanceManagement
{
    public class InstanceCreator : IInstanceCreator
    {
        private Dictionary<Type, Lazy<object>> resolvedInstances = new Dictionary<Type, Lazy<object>>();

        public TInterface GetInstance<TInterface>(Dictionary<Type, Lazy<RegistrationInfoModel>> registrations)
        {
            var interfaceType = typeof(TInterface);
            RegistrationInfoModel registration = FindRegistrationInfoModel(registrations, interfaceType);
            var constructor = registration.Implementation.SmallestConstructor();

            var parameters = constructor.GetParameters();

            if (resolvedInstances.ContainsKey(registration.Implementation))
            {
                return (TInterface)resolvedInstances[registration.Implementation].Value;
            }
            else if (!parameters.Any())
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

        private void GatherConstructorParameterInstances(Dictionary<Type, Lazy<RegistrationInfoModel>> registrations, List<object> instances, System.Reflection.ParameterInfo[] parameters)
        {            
            foreach (var parameter in parameters)
            {
                var registrationForParameter = FindRegistrationInfoModel(registrations, parameter.ParameterType);
                var implementationType = registrationForParameter.Implementation;
                if (resolvedInstances.ContainsKey(implementationType))
                {
                    instances.Add(resolvedInstances[implementationType]);
                }
                else
                {
                    var parameterConstructor = registrationForParameter.Implementation.SmallestConstructor();
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
        }

        private static RegistrationInfoModel FindRegistrationInfoModel(Dictionary<Type, Lazy<RegistrationInfoModel>> registrations, Type interfaceType)
        {
            if (!registrations.ContainsKey(interfaceType))
            {
                throw new NotRegisteredException(interfaceType);
            }
            return registrations[interfaceType].Value;
        }

        private object CreateInstance(Type type, params object[] parameters)
        {
            var instance = Activator.CreateInstance(type, parameters.Any() ? parameters : null);
            resolvedInstances.Add(instance.GetType(), new Lazy<object>(() => instance, isThreadSafe: true));
            return instance;
        }
    }
}
