using SuperPowerEditor.UI.SPEditor.Core.Contracts;
using SuperPowerEditor.UI.SPEditor.Core.Views;

namespace SuperPowerEditor.UI.SPEditor.Core.Presenters
{
    public class MainPresenter : BasePresenter<IMainView, IMainPresenter>, IMainPresenter
    {
        public MainPresenter(IMainView view) : base(view)
        {
        }
    }
}
