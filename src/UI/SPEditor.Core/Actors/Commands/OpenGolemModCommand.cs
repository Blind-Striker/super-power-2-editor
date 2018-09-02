using Akka.Actor;

namespace SuperPowerEditor.UI.SPEditor.Core.Actors.Commands
{
    public class OpenGolemModCommand
    {
        public OpenGolemModCommand(string golemModFilePath, IActorRef sender)
        {
            GolemModFilePath = golemModFilePath;
            Sender = sender;
        }

        public string GolemModFilePath { get; }

        public IActorRef Sender { get; }
    }
}