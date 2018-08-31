namespace SuperPowerEditor.UI.SPEditor.Core.Contracts
{
    public interface IPresenterFactory
    {
        T CreatePresenter<T>()
            where T : IPresenter;

        T CreatePresenter<T>(object argumentsAsAnonymousType)
            where T : IPresenter;
    }
}