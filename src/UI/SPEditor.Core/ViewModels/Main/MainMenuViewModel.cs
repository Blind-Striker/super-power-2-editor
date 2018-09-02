using System.Windows.Input;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;

namespace SuperPowerEditor.UI.SPEditor.Core.ViewModels.Main
{
    public class MainMenuViewModel : BaseViewModel, IMainMenuViewModel
    {
        private ICommand _openGolemModCommand;
        private ICommand _openModCommand;
        private ICommand _designCommand;

        private bool _countryOperationsEnabled;

        public ICommand OpenGolemModCommand
        {
            get => _openGolemModCommand;
            set => RaiseAndSetIfChanged(ref _openGolemModCommand, value);
        }

        public ICommand OpenModCommand
        {
            get => _openModCommand;
            set => RaiseAndSetIfChanged(ref _openModCommand, value);
        }

        public ICommand DesignCommand
        {
            get => _designCommand;
            set => RaiseAndSetIfChanged(ref _designCommand, value);
        }

        public bool CountryOperationsEnabled
        {
            get => _countryOperationsEnabled;
            set => RaiseAndSetIfChanged(ref _countryOperationsEnabled, value);
        }
    }
}
