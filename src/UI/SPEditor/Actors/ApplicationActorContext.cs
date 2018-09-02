using Akka.Actor;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;

namespace SuperPowerEditor.UI.SPEditor.Actors
{
    public class ApplicationActorContext : IApplicationActorContext
    {
        public ApplicationActorContext(ActorSystem actorSystem)
        {
            ActorSystem = actorSystem;
        }

        public ActorSystem ActorSystem { get; }
    }
}
