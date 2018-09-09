using Akka.Actor;
using SuperPowerEditor.Base.BizLogic.Models;

namespace SuperPowerEditor.Base.BizLogic.Actors
{
    public class OperationsCoordinatorActor : ReceiveActor
    {
        private readonly ModMetadata _modMetadata;

        private IActorRef _designOperationsActorRef;
        private IActorRef _modStringTableActorRef;

        public OperationsCoordinatorActor(ModMetadata modMetadata)
        {
            _modMetadata = modMetadata;
        }

        protected override void PreStart()
        {
            _designOperationsActorRef = Context.ActorOf(Props.Create(() => new DesignOperationsActor(_modMetadata)));
            _modStringTableActorRef = Context.ActorOf(Props.Create(() => new ModStringTableActor(_modMetadata)));
        }
    }
}
