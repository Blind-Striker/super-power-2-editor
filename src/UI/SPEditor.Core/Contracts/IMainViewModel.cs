using System.Windows.Input;

namespace SuperPowerEditor.UI.SPEditor.Core.Contracts
{
    public interface IMainViewModel
    {
        IMainMenuViewModel MainMenuViewModel { get; set; }
    }
}