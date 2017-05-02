namespace FacadeNotifier.App.DI
{
    using Autofac;
    using Autofac.Core;
    using Autofac.Core.Activators.Reflection;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ContainerExtensions
    {
        public static IEnumerable<Type> GetImplementingTypes<T>(this ILifetimeScope scope)
        {
            return scope.ComponentRegistry
                .RegistrationsFor(new TypedService(typeof(T)))
                .Select(x => x.Activator)
                .OfType<ReflectionActivator>()
                .Select(x => x.LimitType);
        }
    }
}