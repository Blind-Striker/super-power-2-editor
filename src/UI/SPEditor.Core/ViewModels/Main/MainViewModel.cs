using SuperPowerEditor.UI.SPEditor.Core.Contracts;

namespace SuperPowerEditor.UI.SPEditor.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {
        private IMainMenuViewModel _mainMenuViewModel;

        public MainViewModel()
        {
        }

        public IMainMenuViewModel MainMenuViewModel
        {
            get => _mainMenuViewModel;
            set => RaiseAndSetIfChanged(ref _mainMenuViewModel, value);
        }
    }
}
