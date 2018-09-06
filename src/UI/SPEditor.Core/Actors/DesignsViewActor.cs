using System.Collections.ObjectModel;
using Akka.Actor;
using SuperPowerEditor.Base.BizLogic.Actors;
using SuperPowerEditor.Base.BizLogic.Actors.Commands;
using SuperPowerEditor.Base.BizLogic.Actors.Events;
using SuperPowerEditor.Base.DataAccess.Entities;
using SuperPowerEditor.UI.SPEditor.Core.Actors.Commands;
using SuperPowerEditor.UI.SPEditor.Core.Actors.Events;
using SuperPowerEditor.UI.SPEditor.Core.ViewModels.Design;

namespace SuperPowerEditor.UI.SPEditor.Core.Actors
{
    public class DesignsViewActor : ReceiveActor
    {
        public DesignsViewActor(DesignViewModel designViewModel)
        {
            IActorRef designOperationsActor = Context.ActorOf(Props.Create(() => new DesignOperationsActor()));

            Receive<LoadDesignsCommand>(command =>
            {
                designOperationsActor.Tell(command);
            });

            Receive<CloseDesignsViewCommand>(@event =>
            {
                Self.Tell(PoisonPill.Instance);

                var viewClosedEvent = new DesignViewClosedEvent(@event.DesignViewModel);

                Context.System.EventStream.Publish(viewClosedEvent);
            });

            Receive<DesignsLoadedEvent>(@event =>
            {
                designViewModel.Designs = new ObservableCollection<Design>(@event.Designs);
            });
        }
    }
}
