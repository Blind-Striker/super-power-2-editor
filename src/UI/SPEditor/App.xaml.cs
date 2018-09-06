using System;
using System.Windows;
using Akka.Actor;
using Akka.DI.AutoFac;
using Autofac;
using SuperPowerEditor.UI.SPEditor.Core;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;
using SuperPowerEditor.UI.SPEditor.Modules;

namespace SuperPowerEditor.UI.SPEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            using (ActorSystem actorSys = ActorSystem.Create("super-power-editor-sys"))
            {
                var builder = new ContainerBuilder();
                builder.RegisterInstance(actorSys);

                builder.RegisterModule<SpEditorCoreModule>();
                builder.RegisterModule<SPEditorModule>();

                IContainer container = builder.Build();

                var resolver = new AutoFacDependencyResolver(container, actorSys);

                var presenterFactory = container.Resolve<Func<Type, IPresenter>>();

                var mainPresenter = (IMainPresenter)presenterFactory.Invoke(typeof(IMainPresenter));
                var mainWindow = (MainWindow)mainPresenter.View;

                mainWindow.ShowDialog();
            }
        }
    }
}
