using Akka.Actor;

namespace SuperPowerEditor.UI.SPEditor.Core.Contracts
{
    public interface IInfinityActorContext
    {
        ActorSystem ActorSystem { get; }
    }
}