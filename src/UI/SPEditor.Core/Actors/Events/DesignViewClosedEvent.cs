﻿using SuperPowerEditor.UI.SPEditor.Core.Contracts;

namespace SuperPowerEditor.UI.SPEditor.Core.Actors.Events
{
    public class DesignViewClosedEvent
    {
        public IDesignViewModel DesignViewModel { get; }

        public DesignViewClosedEvent(IDesignViewModel designViewModel)
        {
            DesignViewModel = designViewModel;
        }
    }
}
