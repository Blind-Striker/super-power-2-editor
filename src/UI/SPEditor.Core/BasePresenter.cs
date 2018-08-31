using SuperPowerEditor.UI.SPEditor.Core.Contracts;

namespace SuperPowerEditor.UI.SPEditor.Core
{
    public abstract class BasePresenter<TView, TPresenter> : IPresenter<TView>
        where TView : IPresenteredView<TPresenter> where TPresenter : class, IPresenter
    {
        private readonly TView _view;

        protected BasePresenter(TView view)
        {
            _view = view;
            _view.Presenter = this as TPresenter;
        }

        public TView View => _view;
    }
}