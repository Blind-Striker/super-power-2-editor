using System.Windows.Input;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;

namespace SuperPowerEditor.UI.SPEditor.Core.ViewModels.Design
{
    public class DesignViewModel : BaseViewModel, IDesignViewModel
    {
        private string _title;
        private string _iconSource;
        private ICommand _closeCommand;

        public string Title
        {
            get => _title;
            set => RaiseAndSetIfChanged(ref _title, value);
        }

        public string IconSource
        {
            get => _iconSource;
            set => RaiseAndSetIfChanged(ref _iconSource, value);
        }

        public ICommand CloseCommand
        {
            get => _closeCommand;
            set => RaiseAndSetIfChanged(ref _closeCommand, value);
        }
    }
}
