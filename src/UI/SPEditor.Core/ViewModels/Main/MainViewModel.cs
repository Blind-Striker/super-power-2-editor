using System.Collections.ObjectModel;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;

namespace SuperPowerEditor.UI.SPEditor.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {
        private IMainMenuViewModel _mainMenuViewModel;
        private IViewModel _selectedTabViewModel;
        private ObservableCollection<IViewModel> _tabViewModels;

        public IMainMenuViewModel MainMenuViewModel
        {
            get => _mainMenuViewModel;
            set => RaiseAndSetIfChanged(ref _mainMenuViewModel, value);
        }

        public IViewModel SelectedTabViewModel
        {
            get => _selectedTabViewModel;
            set => RaiseAndSetIfChanged(ref _selectedTabViewModel, value);
        }

        public ObservableCollection<IViewModel> TabViewModels
        {
            get => _tabViewModels;
            set => RaiseAndSetIfChanged(ref _tabViewModels, value);
        }
    }
}
