using System;
using System.Collections.ObjectModel;
using System.Waf.Applications;
using System.Windows.Input;
using Akka.Actor;
using SuperPowerEditor.Base.BizLogic.Actors.Commands;
using SuperPowerEditor.Base.BizLogic.Models;
using SuperPowerEditor.UI.SPEditor.Core.Actors;
using SuperPowerEditor.UI.SPEditor.Core.Actors.Commands;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;

namespace SuperPowerEditor.UI.SPEditor.Core.ViewModels.Design
{
    public class DesignViewModel : BaseViewModel, IDesignViewModel, IDisposable
    {
        private IActorRef _designViewActorRef;

        private string _title;
        private string _iconSource;
        private ICommand _closeCommand;
        private ObservableCollection<DesignModel> _designs;
        private DesignModel _selectedDesign;
        private bool _contentIsSelected;

        public DesignViewModel(IApplicationActorContext applicationActorContext, ModMetadata modMetadata)
        {
            TabHeaderTitle = "Desings";

            _designViewActorRef = applicationActorContext.ActorSystem.ActorOf(Props.Create(() => new DesignsViewActor(this, modMetadata)).WithDispatcher("akka.actor.synchronized-dispatcher"));

            CloseCommand = new DelegateCommand(OnDesignViewClosed);

            _designViewActorRef.Tell(new LoadDesignsCommand(_designViewActorRef));
        }

        private void OnDesignViewClosed()
        {
            _designViewActorRef.Tell(new CloseDesignsViewCommand(this));
        }

        public string TabHeaderTitle
        {
            get => _title;
            set => RaiseAndSetIfChanged(ref _title, value);
        }

        public string IconSource
        {
            get => _iconSource;
            set => RaiseAndSetIfChanged(ref _iconSource, value);
        }

        public ICommand CloseCommand
        {
            get => _closeCommand;
            set => RaiseAndSetIfChanged(ref _closeCommand, value);
        }

        public bool ContentIsSelected
        {
            get => _contentIsSelected;
            set => RaiseAndSetIfChanged(ref _contentIsSelected, value);
        }

        public DesignModel SelectedDesign
        {
            get => _selectedDesign;
            set => RaiseAndSetIfChanged(ref _selectedDesign, value);
        }

        public ObservableCollection<DesignModel> Designs
        {
            get => _designs;
            set => RaiseAndSetIfChanged(ref _designs, value);
        }

        public void Dispose()
        {
            _designViewActorRef = null;
        }
    }
}
