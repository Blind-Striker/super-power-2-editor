﻿using Autofac;
using SuperPowerEditor.UI.SPEditor.Actors;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;
using SuperPowerEditor.UI.SPEditor.Core.Views;
using SuperPowerEditor.UI.SPEditor.UserControls;

namespace SuperPowerEditor.UI.SPEditor.Modules
{
    public class SPEditorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindow>().As<IMainView>().InstancePerDependency();
            builder.RegisterType<Designs>().As<IDesignView>().InstancePerDependency();

            builder.RegisterType<ApplicationActorContext>().As<IApplicationActorContext>().InstancePerDependency();
        }
    }
}
