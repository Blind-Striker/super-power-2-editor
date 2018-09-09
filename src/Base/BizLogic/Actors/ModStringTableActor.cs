using System;
using Akka.Actor;
using SuperPowerEditor.Base.BizLogic.Actors.Commands;
using SuperPowerEditor.Base.BizLogic.Actors.Events;
using SuperPowerEditor.Base.BizLogic.Models;
using SuperPowerEditor.Base.BizLogic.StringTable;

namespace SuperPowerEditor.Base.BizLogic.Actors
{
    public class ModStringTableActor : ReceiveActor
    {
        public ModStringTableActor(ModMetadata modMetadata)
        {
            var dataPath = modMetadata.DataPath;
            var spStringTable = new SpStringTable();
            spStringTable.Load(dataPath);

            Receive<LoadStringTableValueFromIdCommand>(command =>
            {
                try
                {
                    string spString = spStringTable.GetString(command.StId, command.Lang);

                    //string spString = "Deniz";

                    Sender.Tell(new StringTableValueLoadedEvent(command.StId, spString, command.Lang), Self);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            });
        }


        //private void NotInitialized()
        //{
        //    Receive<LoadStringTableValueFromIdCommand>(command =>
        //    {
        //        Self.Tell(new InitializeSpStringTable());

        //        Become(Initializing);
        //    });
        //}

        //private void Initializing()
        //{
        //    Receive<LoadStringTableValueFromIdCommand>(command =>
        //    {
        //        Stash.Stash();
        //    });

        //    Receive<InitializeSpStringTable>(table =>
        //    {
        //        _spStringTable.Load(_dataPath);
        //        Become(Initialized);
        //        Stash.UnstashAll();
        //    });
        //}

        //private void Initialized()
        //{
        //    Receive<LoadStringTableValueFromIdCommand>(command =>
        //    {
        //        string spString = _spStringTable.GetString(command.StId, command.Lang);

        //        Sender.Tell(new StringTableValueLoadedEvent(command.StId, spString, command.Lang), Self);
        //    });
        //}

        //private class InitializeSpStringTable { }
    }
}
