using System;
using System.Waf.Applications;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;
using SuperPowerEditor.UI.SPEditor.Core.ViewModels.Design;
using SuperPowerEditor.UI.SPEditor.Core.Views;

namespace SuperPowerEditor.UI.SPEditor.Core.Presenters
{
    public class DesignPresenter : BasePresenter<IDesignView, IDesignPresenter>, IDesignPresenter
    {
        public DesignPresenter(IDesignView view) : base(view)
        {
            var designViewModel = new DesignViewModel {Title = "Designs", CloseCommand = new DelegateCommand(OnClose)};

            View.DataContext = designViewModel;
        }

        private void OnClose()
        {
            DesignViewClosed?.Invoke(this);
        }

        public Action<IDesignPresenter> DesignViewClosed { get; set; }
    }
}
