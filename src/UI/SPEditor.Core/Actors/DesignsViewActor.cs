using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Akka.Actor;
using Akka.Streams;
using Akka.Streams.Dsl;
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
            //IActorRef stringTableActorRef = Context.ActorOf(Props.Create(() => new ModStringTableActor(modMetadata)));
            //IActorRef designOperationsActorRef = Context.ActorOf(Props.Create(() => new DesignOperationsActor(modMetadata)));

            int processorCount = Environment.ProcessorCount;

            Receive<LoadDesignsCommand>(command => { designOperationsActorRef.Tell(command); });

            Receive<CloseDesignsViewCommand>(@event =>
            {
                Self.Tell(PoisonPill.Instance);

                var viewClosedEvent = new DesignViewClosedEvent(@event.DesignViewModel);

                Context.System.EventStream.Publish(viewClosedEvent);
            });

            Receive<DesignsLoadedEvent>(async @event =>
            {
                using (var mat = Context.Materializer())
                {
                    IList<StringTableValueLoadedEvent> events = new List<StringTableValueLoadedEvent>();

                    await Source.From(@event.Designs)
                        .SelectAsync(processorCount,
                            design => stringTableActorRef.Ask(
                                new LoadStringTableValueFromIdCommand(design.Name ?? -1, "english")))
                        .Select(o => (StringTableValueLoadedEvent) o)
                        .RunWith(Sink.ForEach<StringTableValueLoadedEvent>(loadedEvent => events.Add(loadedEvent)), mat)
                        .PipeTo(Self, Self,
                            () =>
                            {
                                IList<DesignModel> designModels = new List<DesignModel>(@event.Designs.Count);

                                foreach (Design eventDesign in @event.Designs)
                                {
                                    var stringTableValue = events.FirstOrDefault(loadedEvent =>
                                        loadedEvent.StId == eventDesign.Name);

                                    DesignModel designModel = new DesignModel(eventDesign.Id, eventDesign.DesignId,
                                        eventDesign.CountryDesignerRef?.Code, eventDesign.TypeRef,
                                        stringTableValue?.StValue,
                                        eventDesign.Speed, eventDesign.Sensors, eventDesign.GunRange,
                                        eventDesign.GunPrecision, eventDesign.GunDamage, eventDesign.MissilePayload,
                                        eventDesign.MissileRange, eventDesign.MissilePrecision,
                                        eventDesign.MissileDamage, eventDesign.Stealth, eventDesign.Countermeasures,
                                        eventDesign.Armor, eventDesign.Piece1, eventDesign.Piece2, eventDesign.Piece3,
                                        eventDesign.Texture);

                                    designModels.Add(designModel);
                                }

                                designViewModel.Designs = new ObservableCollection<DesignModel>(designModels);

                                return designModels;
                            });
                }
            });
        }

        protected override void PreStart()
        {
            base.PreStart();
        }
    }
}
