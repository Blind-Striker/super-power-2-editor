using SuperPowerEditor.UI.SPEditor.Core.Contracts;
using SuperPowerEditor.UI.SPEditor.Core.Presenters;

namespace SuperPowerEditor.UI.SPEditor.Core.Views
{
    public interface IDesignView : IPresenteredView<IDesignPresenter>
    {
        object DataContext { get; set; }
    }
}