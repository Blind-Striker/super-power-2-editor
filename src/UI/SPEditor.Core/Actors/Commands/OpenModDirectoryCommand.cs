using Akka.Actor;

namespace SuperPowerEditor.UI.SPEditor.Core.Actors.Commands
{
    public class OpenModDirectoryCommand
    {
        public OpenModDirectoryCommand(string modDirectoryPath, IActorRef sender)
        {
            ModDirectoryPath = modDirectoryPath;
            Sender = sender;
        }

        public string ModDirectoryPath { get; }

        public IActorRef Sender { get; }
    }
}
