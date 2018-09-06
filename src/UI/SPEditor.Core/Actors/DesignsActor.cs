using Akka.Actor;
using SuperPowerEditor.Base.BizLogic.Actors;
using SuperPowerEditor.Base.BizLogic.Actors.Commands;

namespace SuperPowerEditor.UI.SPEditor.Core.Actors
{
    public class DesignsActor : ReceiveActor
    {
        public DesignsActor()
        {
            IActorRef designOperationsActor = Context.ActorOf(Props.Create(() => new DesignOperationsActor()));

            Receive<LoadDesignsCommand>(command =>
            {
                designOperationsActor.Tell(command);
            });
        }
    }
}
