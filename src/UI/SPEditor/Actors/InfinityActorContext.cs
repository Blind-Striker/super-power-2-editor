using Akka.Actor;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;

namespace SuperPowerEditor.UI.SPEditor.Actors
{
    public class InfinityActorContext : IInfinityActorContext
    {
        public InfinityActorContext(ActorSystem actorSystem)
        {
            ActorSystem = actorSystem;
        }

        public ActorSystem ActorSystem { get; }
    }
}
