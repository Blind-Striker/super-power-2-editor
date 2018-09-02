using System.Collections.ObjectModel;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;
using SuperPowerEditor.UI.SPEditor.Core.ViewModels.Design;

namespace SuperPowerEditor.UI.SPEditor.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {
        private IMainMenuViewModel _mainMenuViewModel;
        private ObservableCollection<IViewModel> _designViewModels;

        public MainViewModel()
        {
        }

        public IMainMenuViewModel MainMenuViewModel
        {
            get => _mainMenuViewModel;
            set => RaiseAndSetIfChanged(ref _mainMenuViewModel, value);
        }

        public ObservableCollection<IViewModel> DesignViewModels
        {
            get => _designViewModels;
            set => RaiseAndSetIfChanged(ref _designViewModels, value);
        }
    }
}
