using System.Collections.ObjectModel;
using System.Windows.Input;
using SuperPowerEditor.UI.SPEditor.Core.ViewModels.Design;

namespace SuperPowerEditor.UI.SPEditor.Core.Contracts
{
    public interface IMainViewModel
    {
        IMainMenuViewModel MainMenuViewModel { get; set; }
        ObservableCollection<IViewModel> DesignViewModels { get; set; }
    }
}