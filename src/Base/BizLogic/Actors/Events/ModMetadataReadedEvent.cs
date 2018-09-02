using System;
using System.Collections.Generic;
using System.Text;
using SuperPowerEditor.Base.BizLogic.Models;

namespace SuperPowerEditor.Base.BizLogic.Actors.Events
{
    public class ModMetadataReadedEvent
    {
        public ModMetadataReadedEvent(string status, IList<string> errors, ModMetadata modMetadata)
        {
            Status = status;
            Errors = errors;
            ModMetadata = modMetadata;
        }

        public string Status { get; set; }

        public IList<string> Errors { get; set; }

        public ModMetadata ModMetadata { get; set; }
    }
}
