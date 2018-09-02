using System.Windows.Input;

namespace SuperPowerEditor.UI.SPEditor.Core.Contracts
{
    public interface IDesignViewModel : IViewModel
    {
        string Title { get; set; }
        string IconSource { get; set; }
        ICommand CloseCommand { get; set; }
    }
}