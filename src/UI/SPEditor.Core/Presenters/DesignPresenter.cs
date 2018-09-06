using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Waf.Applications;
using Akka.Actor;
using SuperPowerEditor.Base.BizLogic.Actors.Commands;
using SuperPowerEditor.Base.DataAccess.Entities;
using SuperPowerEditor.UI.SPEditor.Core.Actors;
using SuperPowerEditor.UI.SPEditor.Core.Actors.Commands;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;
using SuperPowerEditor.UI.SPEditor.Core.ViewModels.Design;
using SuperPowerEditor.UI.SPEditor.Core.Views;

namespace SuperPowerEditor.UI.SPEditor.Core.Presenters
{
    //public class DesignPresenter : BasePresenter<IDesignView, IDesignPresenter>, IDesignPresenter
    //{
    //    private readonly IApplicationActorContext _applicationActorContext;

    //    private readonly IDesignViewModel _designViewModel;

    //    private IActorRef _designerPresenterActor;

    //    public DesignPresenter(IDesignView view, IApplicationActorContext applicationActorContext) : base(view)
    //    {
    //        _applicationActorContext = applicationActorContext;

    //        _designViewModel = new DesignViewModel { TabHeaderTitle = "Designs" };

    //        InitializeViewModels();
    //        InitializeActors();

    //       _designerPresenterActor.Tell(new LoadDesignsCommand(_designerPresenterActor, @"E:\SteamLibrary\steamapps\common\SuperPower 2\MODS\Geopolitics\data\DATABASE.gdb"));
    //    }

    //    internal void OnDesignsLoaded(IList<Design> designs)
    //    {
    //        _designViewModel.Designs = new ObservableCollection<Design>(designs);
    //        _designViewModel.SelectedDesign = designs[0];
    //    }

    //    private void InitializeViewModels()
    //    {
    //        _designViewModel.CloseCommand = new DelegateCommand(OnClose);

    //        View.DataContext = _designViewModel;
    //    }

    //    private void InitializeActors()
    //    {
    //        _designerPresenterActor = _applicationActorContext.ActorSystem.ActorOf(Props.Create(() => new DesignerPresenterActor(this)).WithDispatcher("akka.actor.synchronized-dispatcher"));
    //    }

    //    private void OnClose()
    //    {
    //        _designerPresenterActor.Tell(new CloseDesignViewCommand());
    //    }
    //}
}
