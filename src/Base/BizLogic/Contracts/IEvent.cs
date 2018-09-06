using System.Collections.Generic;
using SuperPowerEditor.Base.BizLogic.Models;

namespace SuperPowerEditor.Base.BizLogic.Contracts
{
    public interface IEvent
    {
        Status Status { get; }
        IList<string> Errors { get;  }
    }
}