using System.Collections.ObjectModel;

namespace SuperPowerEditor.UI.SPEditor.Core.Contracts
{
    public interface IMainViewModel
    {
        IMainMenuViewModel MainMenuViewModel { get; set; }
        ObservableCollection<IViewModel> TabViewModels { get; set; }
    }
}