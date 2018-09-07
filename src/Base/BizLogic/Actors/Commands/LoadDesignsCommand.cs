using Akka.Actor;

namespace SuperPowerEditor.Base.BizLogic.Actors.Commands
{
    public class LoadDesignsCommand
    {
        public LoadDesignsCommand(IActorRef sender)
        {
            Sender = sender;
        }

        public IActorRef Sender { get; }
    }
}
