using Akka.Actor;

namespace SuperPowerEditor.Base.BizLogic.Actors.Commands
{
    public class LoadModMetadataCommand
    {
        public LoadModMetadataCommand(IActorRef sender, ModType modType, string path)
        {
            Sender = sender;
            ModType = modType;
            Path = path;
        }

        public IActorRef Sender { get; }

        public ModType ModType { get; }

        public string Path { get; }
    }

    public enum ModType
    {
        GolemMod,
        DirectoryMod
    }
}
