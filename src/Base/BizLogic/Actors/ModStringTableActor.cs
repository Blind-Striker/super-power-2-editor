using Akka.Actor;
using SuperPowerEditor.Base.BizLogic.Actors.Commands;
using SuperPowerEditor.Base.BizLogic.Models;
using SuperPowerEditor.Base.BizLogic.StringTable;

namespace SuperPowerEditor.Base.BizLogic.Actors
{
    public class ModStringTableActor : ReceiveActor, IWithUnboundedStash
    {
        private readonly string _dataPath;
        private readonly SpStringTable _spStringTable;

        public ModStringTableActor(ModMetadata modMetadata)
        {
            _dataPath = modMetadata.DataPath;
            _spStringTable = new SpStringTable();

            Become(NotInitialized);
        }

        public IStash Stash { get; set; }

        private void NotInitialized()
        {
            Receive<GetStringTableValueFromIdCommand>(command =>
            {
                Become(Initializing);

                Self.Tell(new InitializeSpStringTable());
            });
        }

        private void Initializing()
        {
            Receive<GetStringTableValueFromIdCommand>(command =>
            {
                Stash.Stash();
            });

            Receive<InitializeSpStringTable>(table =>
            {
                _spStringTable.Load(_dataPath);
                Become(Initialized);
                Stash.UnstashAll();
            });
        }

        private void Initialized()
        {
            Receive<GetStringTableValueFromIdCommand>(command =>
            {
                string spString = _spStringTable.GetString(command.StId, command.Lang);

                Sender.Tell(spString, Self);
            });
        }

        private class InitializeSpStringTable { }
    }
}
