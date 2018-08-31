namespace SuperPowerEditor.UI.SPEditor.Core.Contracts
{
    public interface IPresenteredView<TPresenter> : IView
    {
        TPresenter Presenter { set; get; }
    }
}