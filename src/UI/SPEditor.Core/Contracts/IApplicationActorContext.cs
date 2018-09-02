using Akka.Actor;

namespace SuperPowerEditor.UI.SPEditor.Core.Contracts
{
    public interface IApplicationActorContext
    {
        ActorSystem ActorSystem { get; }
    }
}