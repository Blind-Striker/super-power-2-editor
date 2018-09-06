using Akka.Actor;

namespace SuperPowerEditor.Base.BizLogic.Actors.Commands
{
    public class LoadDesignsCommand
    {
        public LoadDesignsCommand(IActorRef sender, string databasePath)
        {
            Sender = sender;
            DatabasePath = databasePath;
        }

        public IActorRef Sender { get; }
        public string DatabasePath { get; }
    }
}
