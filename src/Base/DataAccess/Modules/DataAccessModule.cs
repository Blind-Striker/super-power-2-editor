using Autofac;

namespace SuperPowerEditor.Base.DataAccess.Modules
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SuperPowerEditorDbContext>().InstancePerLifetimeScope();
        }
    }
}
