using System;
using System.Collections.Generic;
using System.Text;

namespace SuperPowerEditor.Base.BizLogic.Actors.Events
{
    public class StringTableValueLoadedEvent
    {
        public StringTableValueLoadedEvent(int stId, string stValue, string lang)
        {
            StId = stId;
            StValue = stValue;
            Lang = lang;
        }

        public int StId { get; }
        public string StValue { get; }
        public string Lang { get; }
    }
}
