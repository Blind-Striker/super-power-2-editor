using System.Collections.Generic;
using System.Linq;
using Akka.Actor;
using FirebirdSql.Data.FirebirdClient;
using SuperPowerEditor.Base.BizLogic.Actors.Commands;
using SuperPowerEditor.Base.BizLogic.Actors.Events;
using SuperPowerEditor.Base.DataAccess;
using SuperPowerEditor.Base.DataAccess.Entities;

namespace SuperPowerEditor.Base.BizLogic.Actors
{
    // TODO : call via coordinator
    public class DesignOperationsActor : ReceiveActor
    {
        public DesignOperationsActor()
        {
            Receive<LoadDesignsCommand>(command =>
            {
                var connectionString = new FbConnectionStringBuilder
                {
                    Database = command.DatabasePath,
                    ServerType = FbServerType.Embedded,
                    UserID = "SYSDBA",
                    Password = "masterkey",
                    ClientLibrary = "fbembed.dll"
                }.ToString();

                using (SuperPowerEditorDbContext context = new SuperPowerEditorDbContext(connectionString))
                {
                    List<Design> designs = context.Designs.ToList();

                    command.Sender.Tell(new DesignsLoadedEvent(designs));
                }
            });
        }
    }
}
