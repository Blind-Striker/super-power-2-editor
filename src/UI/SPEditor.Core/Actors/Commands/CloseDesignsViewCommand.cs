using SuperPowerEditor.UI.SPEditor.Core.Contracts;

namespace SuperPowerEditor.UI.SPEditor.Core.Actors.Commands
{
    public class CloseDesignsViewCommand
    {
        public IDesignViewModel DesignViewModel { get; }

        public CloseDesignsViewCommand(IDesignViewModel designViewModel)
        {
            DesignViewModel = designViewModel;
        }
    }
}
