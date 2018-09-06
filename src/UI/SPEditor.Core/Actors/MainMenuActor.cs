using Akka.Actor;
using SuperPowerEditor.Base.BizLogic.Actors;
using SuperPowerEditor.Base.BizLogic.Actors.Commands;
using SuperPowerEditor.UI.SPEditor.Core.Actors.Commands;

namespace SuperPowerEditor.UI.SPEditor.Core.Actors
{
    public class MainMenuActor : ReceiveActor
    {
        public MainMenuActor()
        {
            var modMetadataActorRef = Context.ActorOf(Props.Create(() => new ModMetadataActor()));

            Receive<OpenModDirectoryCommand>(command =>
            {
                var readModMetadataCommand = new LoadModMetadataCommand(command.Sender, ModType.DirectoryMod, command.ModDirectoryPath);

                modMetadataActorRef.Tell(readModMetadataCommand);
            });

            Receive<OpenGolemModCommand>(command =>
            {
                var readModMetadataCommand = new LoadModMetadataCommand(command.Sender, ModType.GolemMod, command.GolemModFilePath);

                modMetadataActorRef.Tell(readModMetadataCommand);
            });
        }
    }
}
