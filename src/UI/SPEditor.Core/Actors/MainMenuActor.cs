using Akka.Actor;
using SuperPowerEditor.Base.BizLogic.Actors.Commands;
using SuperPowerEditor.UI.SPEditor.Core.Actors.Commands;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;

namespace SuperPowerEditor.UI.SPEditor.Core.Actors
{
    public class MainMenuActor : ReceiveActor
    {
        public MainMenuActor(IActorRef modMetadataActorRef, IMainMenuViewModel mainMenuViewModel)
        {
            Receive<OpenModDirectoryCommand>(command =>
            {
                var readModMetadataCommand = new ReadModMetadataCommand(command.Sender, ModType.DirectoryMod, command.ModDirectoryPath);

                modMetadataActorRef.Tell(readModMetadataCommand);
            });

            Receive<OpenGolemModCommand>(command =>
            {
                var readModMetadataCommand = new ReadModMetadataCommand(command.Sender, ModType.GolemMod, command.GolemModFilePath);

                modMetadataActorRef.Tell(readModMetadataCommand);
            });
        }
    }
}
