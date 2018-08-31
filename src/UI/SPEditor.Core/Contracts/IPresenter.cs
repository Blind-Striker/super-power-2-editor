namespace SuperPowerEditor.UI.SPEditor.Core.Contracts
{
    //Marker interface
    public interface IPresenter
    {

    }

    public interface IPresenter<out TView> : IPresenter
        where TView : IView
    {
        TView View { get; }
    }
}
