using System.Windows.Input;

namespace SuperPowerEditor.UI.SPEditor.Core.Contracts
{
    public interface IMainMenuViewModel
    {
        ICommand OpenGolemModCommand { get; set; }
        ICommand OpenModCommand { get; set; }
        bool CountryOperationsEnabled { get; set; }
        ICommand DesignCommand { get; set; }
    }
}