using Akka.Actor;
using SuperPowerEditor.Base.BizLogic.Actors.Events;
using SuperPowerEditor.UI.SPEditor.Core.Actors.Commands;
using SuperPowerEditor.UI.SPEditor.Core.Actors.Events;
using SuperPowerEditor.UI.SPEditor.Core.Presenters;

namespace SuperPowerEditor.UI.SPEditor.Core.Actors
{
    public class MainViewActor : ReceiveActor
    {
        public MainViewActor(MainPresenter mainPresenter)
        {
            Context.System.EventStream.Subscribe(Self, typeof(DesignViewClosedEvent));

            IActorRef mainMenuActor = Context.ActorOf(Props.Create(() => new MainMenuActor()).WithDispatcher("akka.actor.synchronized-dispatcher"));

            Receive<OpenModDirectoryCommand>(command =>
            {
                mainMenuActor.Tell(command);
            });

            Receive<OpenGolemModCommand>(command =>
            {
                mainMenuActor.Tell(command);
            });

            Receive<ModMetadataLoadedEvent>(@event =>
            {
                mainPresenter.OnModMetadataLoaded(@event);
            });

            Receive<DesignViewClosedEvent>(@event =>
            {
                mainPresenter.OnDesignViewClosed(@event);
            });
        }
    }
}
