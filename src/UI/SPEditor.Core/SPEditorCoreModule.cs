using System;
using System.Linq;
using Autofac;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;
using SuperPowerEditor.UI.SPEditor.Core.Presenters;
using SuperPowerEditor.UI.SPEditor.Core.ViewModels;

namespace SuperPowerEditor.UI.SPEditor.Core
{
    public class SPEditorCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainPresenter>().As<IMainPresenter>().InstancePerDependency();
            //builder.RegisterType<MainWindow>().As<IMainView>().InstancePerDependency();
            builder.RegisterType<MainViewModel>().As<IMainViewModel>().InstancePerDependency();
            //builder.RegisterType<InfinityActorContext>().As<IInfinityActorContext>().InstancePerDependency();

            builder.Register<Func<Type, IPresenter>>(c =>
            {
                var context = c.Resolve<IComponentContext>();

                return (presenterType) =>
                {
                    if (!presenterType.IsTheGenericType(typeof(IPresenter<>)))
                    {
                        throw new ArgumentException("Only IPresenter<> can be 'implemented'.");
                    }

                    return context.Resolve(presenterType) as IPresenter;
                };
            });
        }
    }

    public static class TypeExtensions
    {
        public static bool IsTheGenericType(this Type candidateType, Type genericType)
        {
            return
                candidateType != null && genericType != null &&
                (candidateType.IsGenericType && candidateType.GetGenericTypeDefinition() == genericType ||
                 candidateType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == genericType) ||
                 candidateType.BaseType != null && candidateType.BaseType.IsTheGenericType(genericType));
        }
    }
}
