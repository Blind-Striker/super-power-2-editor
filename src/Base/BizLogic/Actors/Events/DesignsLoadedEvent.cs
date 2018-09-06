using System.Collections.Generic;
using Akka.Actor;
using SuperPowerEditor.Base.BizLogic.Contracts;
using SuperPowerEditor.Base.DataAccess.Entities;
using Status = SuperPowerEditor.Base.BizLogic.Models.Status;

namespace SuperPowerEditor.Base.BizLogic.Actors.Events
{
    public class DesignsLoadedEvent : IEvent
    {
        public DesignsLoadedEvent(IList<Design> designs, Status status = Status.Success, IList<string> errors = null)
        {
            Designs = designs;
            Status = status;
            Errors = errors;
        }

        public IList<Design> Designs { get; }
        public Status Status { get; }
        public IList<string> Errors { get; }
    }
}
