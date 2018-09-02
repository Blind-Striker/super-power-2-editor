using Akka.Actor;
using SuperPowerEditor.Base.BizLogic.Actors.Events;
using SuperPowerEditor.UI.SPEditor.Core.Presenters;

namespace SuperPowerEditor.UI.SPEditor.Core.Actors
{
    public class MainPresenterActor : ReceiveActor
    {
        public MainPresenterActor(MainPresenter mainPresenter)
        {
            Receive<ModMetadataReadedEvent>(@event =>
            {
                mainPresenter.SetModMetadata(@event.ModMetadata);
            });
        }
    }
}
