using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;

namespace SuperPowerEditor.UI.SPEditor.Core.ViewModels.Main
{
    public class MainMenuViewModel : BaseViewModel, IMainMenuViewModel
    {
        private ICommand _openGolemModCommand;
        private ICommand _openModCommand;

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
    }
}
