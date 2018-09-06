using System.Collections.Generic;
using SuperPowerEditor.Base.BizLogic.Contracts;
using SuperPowerEditor.Base.BizLogic.Models;

namespace SuperPowerEditor.Base.BizLogic.Actors.Events
{
    public class ModMetadataLoadedEvent : IEvent
    {
        public ModMetadataLoadedEvent(ModMetadata modMetadata, Status status = Status.Success, IList<string> errors = null)
        {
            Status = status;
            Errors = errors;
            ModMetadata = modMetadata;
        }

        public Status Status { get; }

        public IList<string> Errors { get; }

        public ModMetadata ModMetadata { get; }
    }
}
