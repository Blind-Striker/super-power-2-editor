using System.Collections.ObjectModel;
using System.Waf.Applications;
using System.Waf.Applications.Services;
using System.Windows.Forms;
using Akka.Actor;
using SuperPowerEditor.Base.BizLogic.Actors.Events;
using SuperPowerEditor.Base.BizLogic.Models;
using SuperPowerEditor.UI.SPEditor.Core.Actors;
using SuperPowerEditor.UI.SPEditor.Core.Actors.Commands;
using SuperPowerEditor.UI.SPEditor.Core.Actors.Events;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;
using SuperPowerEditor.UI.SPEditor.Core.ViewModels.Design;
using SuperPowerEditor.UI.SPEditor.Core.ViewModels.Main;
using SuperPowerEditor.UI.SPEditor.Core.Views;

namespace SuperPowerEditor.UI.SPEditor.Core.Presenters
{
    public class MainPresenter : BasePresenter<IMainView, IMainPresenter>, IMainPresenter
    {
        private readonly IFileDialogService _fileDialogService;
        private readonly IApplicationActorContext _applicationActorContext;

        private readonly IMainViewModel _mainViewModel;

        private IActorRef _mainViewActorRef;

        private ModMetadata _modMetadata;

        public MainPresenter(IMainView view, IFileDialogService fileDialogService, IApplicationActorContext applicationActorContext) : base(view)
        {
            _fileDialogService = fileDialogService;
            _applicationActorContext = applicationActorContext;
            _mainViewModel = new MainViewModel();

            InitializeViewModels();
            InitializeActors();
        }

        internal void OnModMetadataLoaded(ModMetadataLoadedEvent eventModMetadata)
        {
            // TODO : check errors;
            _modMetadata = eventModMetadata.ModMetadata;
            _mainViewModel.MainMenuViewModel.CountryOperationsEnabled = true;
        }


        internal void OnDesignViewClosed(DesignViewClosedEvent @event)
        {
            _mainViewModel.TabViewModels.Remove(@event.DesignViewModel);
        }

        private void InitializeActors()
        {
            _mainViewActorRef = _applicationActorContext.ActorSystem.ActorOf(Props.Create(() => new MainViewActor(this)).WithDispatcher("akka.actor.synchronized-dispatcher"));
        }

        private void InitializeViewModels()
        {
            _mainViewModel.MainMenuViewModel = new MainMenuViewModel()
            {
                OpenGolemModCommand = new DelegateCommand(OnGolemOpenModClicked, () => false),
                OpenModCommand = new DelegateCommand(OnOpenOpenModClicked, () => true),
                DesignCommand =  new DelegateCommand(OnOpenDesignsClicked)
            };

            _mainViewModel.TabViewModels = new ObservableCollection<IViewModel>();

            View.DataContext = _mainViewModel;
        }

        private void OnGolemOpenModClicked()
        {
            FileDialogResult showOpenFileDialog = _fileDialogService.ShowOpenFileDialog(View, new FileType("Golem MOD Information", "*.gmi"));

            if (!showOpenFileDialog.IsValid)
            {
                return;
            }

            var golemModFilePath = showOpenFileDialog.FileName;

            var openGolemModCommand = new OpenGolemModCommand(golemModFilePath, _mainViewActorRef);

            _mainViewActorRef.Tell(openGolemModCommand);
        }

        private void OnOpenOpenModClicked()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();

                if (result != DialogResult.OK)
                {
                    return;
                }

                string directoryPath = dialog.SelectedPath;

                var openModDirectoryCommand = new OpenModDirectoryCommand(directoryPath, _mainViewActorRef);

                _mainViewActorRef.Tell(openModDirectoryCommand);
            }
        }

        private void OnOpenDesignsClicked()
        {
            // TODO: Error handling try remove akka.actor.synchronized-dispatcher

            _mainViewModel.TabViewModels.Add(new DesignViewModel(_applicationActorContext, _modMetadata)
            {
                ContentIsSelected = true
            });
        }
    }
}
