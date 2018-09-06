using Akka.Actor;
using SuperPowerEditor.Base.BizLogic.Actors.Commands;
using SuperPowerEditor.Base.BizLogic.Actors.Events;
using SuperPowerEditor.UI.SPEditor.Core.Actors.Commands;
using SuperPowerEditor.UI.SPEditor.Core.Actors.Events;
using SuperPowerEditor.UI.SPEditor.Core.Presenters;

namespace SuperPowerEditor.UI.SPEditor.Core.Actors
{
    public class MainPresenterActor : ReceiveActor
    {
        private IActorRef _designsActorRef;

        public MainPresenterActor(MainPresenter mainPresenter)
        {
            IActorRef mainMenuActor = Context.ActorOf(Props.Create(() => new MainMenuActor()).WithDispatcher("akka.actor.synchronized-dispatcher"));

            Receive<OpenModDirectoryCommand>(command =>
            {
                mainMenuActor.Tell(command);
            });

            Receive<OpenGolemModCommand>(command =>
            {
                mainMenuActor.Tell(command);
            });

            Receive<LoadDesignsCommand>(command =>
            {
                _designsActorRef = Context.ActorOf(Props.Create(() => new DesignsActor()).WithDispatcher("akka.actor.synchronized-dispatcher"));
                _designsActorRef.Tell(command);
            });

            Receive<CloseDesignViewCommand>(@event =>
            {
                _designsActorRef?.Tell(PoisonPill.Instance);
                _designsActorRef = null;
                Context.System.EventStream.Publish(new DesignViewClosedEvent());
            });

            Receive<ModMetadataLoadedEvent>(@event =>
            {
                mainPresenter.OnModMetadataLoaded(@event.ModMetadata);
            });

            Receive<DesignsLoadedEvent>(@event =>
            {
                mainPresenter.OnDesignsLoaded(@event.Designs);
            });
        }
    }
}
