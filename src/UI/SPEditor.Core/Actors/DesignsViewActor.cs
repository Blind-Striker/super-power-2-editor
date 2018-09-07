using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Akka.Actor;
using Akka.Streams.Dsl;
using SuperPowerEditor.Base.BizLogic.Actors;
using SuperPowerEditor.Base.BizLogic.Actors.Commands;
using SuperPowerEditor.Base.BizLogic.Actors.Events;
using SuperPowerEditor.Base.BizLogic.Models;
using SuperPowerEditor.Base.DataAccess.Entities;
using SuperPowerEditor.UI.SPEditor.Core.Actors.Commands;
using SuperPowerEditor.UI.SPEditor.Core.Actors.Events;
using SuperPowerEditor.UI.SPEditor.Core.ViewModels.Design;

namespace SuperPowerEditor.UI.SPEditor.Core.Actors
{
    public class DesignsViewActor : ReceiveActor
    {
        private IList<Design> _designs;

        public DesignsViewActor(DesignViewModel designViewModel, ModMetadata modMetadata)
        {
            // TODO : move to coordinator
            IActorRef stringTableActorRef = Context.ActorOf(Props.Create(() => new ModStringTableActor(modMetadata)));
            IActorRef designOperationsActorRef = Context.ActorOf(Props.Create(() => new DesignOperationsActor(modMetadata)));

            int processorCount = Environment.ProcessorCount;

            Receive<LoadDesignsCommand>(command =>
            {
                designOperationsActorRef.Tell(command);
            });

            Receive<CloseDesignsViewCommand>(@event =>
            {
                Self.Tell(PoisonPill.Instance);

                var viewClosedEvent = new DesignViewClosedEvent(@event.DesignViewModel);

                Context.System.EventStream.Publish(viewClosedEvent);
            });

            Receive<DesignsLoadedEvent>(@event =>
            {
                //_designs = @event.Designs;

                //foreach (Design design in _designs)
                //{
                //    stringTableActorRef
                //        .Tell(new GetStringTableValueFromIdCommand(design.Name ?? -1, "english"));
                //}

                ////IList<Design> designs = @event.Designs;
                ////var designsSource = Source.From(designs);
                ////Source.ActorRef<>()

                ////Flow.Create<>

                ////designsSource
                ////    .SelectAsync(processorCount, design => stringTableActorRef.Ask(new GetStringTableValueFromIdCommand(design.Name ?? -1, "english")))
                ////    .Select(o => o.ToString())
                ////    .

                designViewModel.Designs = new ObservableCollection<Design>(@event.Designs);
            });
        }
    }
}
