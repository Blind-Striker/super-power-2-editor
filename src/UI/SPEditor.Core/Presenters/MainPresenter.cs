using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Waf.Applications;
using System.Waf.Applications.Services;
using System.Windows.Forms;
using Akka.Actor;
using SuperPowerEditor.Base.BizLogic.Actors;
using SuperPowerEditor.Base.BizLogic.Models;
using SuperPowerEditor.UI.SPEditor.Core.Actors;
using SuperPowerEditor.UI.SPEditor.Core.Actors.Commands;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;
using SuperPowerEditor.UI.SPEditor.Core.ViewModels.Design;
using SuperPowerEditor.UI.SPEditor.Core.ViewModels.Main;
using SuperPowerEditor.UI.SPEditor.Core.Views;
using IView = SuperPowerEditor.UI.SPEditor.Core.Contracts.IView;

namespace SuperPowerEditor.UI.SPEditor.Core.Presenters
{
    public class MainPresenter : BasePresenter<IMainView, IMainPresenter>, IMainPresenter
    {
        private readonly IFileDialogService _fileDialogService;
        private readonly IApplicationActorContext _applicationActorContext;
        private readonly Func<Type, IPresenter> _presenterFactory;

        private readonly IMainViewModel _mainViewModel;

        private IActorRef _mainMenuActorRef;
        private IActorRef _mainPresenterRef;
        private IActorRef _modMetadataActorRef;

        private ModMetadata _modMetadata;

        public MainPresenter(IMainView view, IFileDialogService fileDialogService, IApplicationActorContext applicationActorContext, Func<Type, IPresenter> presenterFactory) : base(view)
        {
            _fileDialogService = fileDialogService;
            _applicationActorContext = applicationActorContext;
            _presenterFactory = presenterFactory;
            _mainViewModel = new MainViewModel();

            InitializeViewModels();

            InitializeActors();
        }

        public void SetModMetadata(ModMetadata eventModMetadata)
        {
            _modMetadata = eventModMetadata;

            _mainViewModel.MainMenuViewModel.CountryOperationsEnabled = true;
        }

        private void InitializeActors()
        {
            _mainPresenterRef = _applicationActorContext.ActorSystem.ActorOf(Props.Create(() => new MainPresenterActor(this)).WithDispatcher("akka.actor.synchronized-dispatcher"));        
            _modMetadataActorRef = _applicationActorContext.ActorSystem.ActorOf(Props.Create(() => new ModMetadataActor()));
            _mainMenuActorRef = _applicationActorContext.ActorSystem.ActorOf(Props.Create(() => new MainMenuActor(_modMetadataActorRef, _mainViewModel.MainMenuViewModel)).WithDispatcher("akka.actor.synchronized-dispatcher"));
        }

        private void InitializeViewModels()
        {
            _mainViewModel.MainMenuViewModel = new MainMenuViewModel()
            {
                OpenGolemModCommand = new DelegateCommand(OnGolemOpenModClicked, () => false),
                OpenModCommand = new DelegateCommand(OpenOpenModClicked, () => true),
                DesignCommand =  new DelegateCommand(OpenDesignsClicked)
            };

            _mainViewModel.DesignViewModels = new ObservableCollection<IViewModel>();

            View.DataContext = _mainViewModel;
        }

        private void OnGolemOpenModClicked()
        {
            FileDialogResult showOpenFileDialog = _fileDialogService.ShowOpenFileDialog(View, new FileType("Golem MOD Information", "*.gmi"));

            if (showOpenFileDialog.IsValid)
            {
                var golemModFilePath = showOpenFileDialog.FileName;

                var openGolemModCommand = new OpenGolemModCommand(golemModFilePath, _mainPresenterRef);

                _mainMenuActorRef.Tell(openGolemModCommand);
            }
        }

        private void OpenOpenModClicked()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string directoryPath = dialog.SelectedPath;

                    var openModDirectoryCommand = new OpenModDirectoryCommand(directoryPath, _mainPresenterRef);

                    _mainMenuActorRef.Tell(openModDirectoryCommand);
                }
            }
        }

        private void OpenDesignsClicked()
        {
            // TODO: Error handling try remove akka.actor.synchronized-dispatcher
            var designPresenter = (IDesignPresenter)_presenterFactory.Invoke(typeof(IDesignPresenter));
            var designViewModel = designPresenter.View.DataContext as IDesignViewModel;

            designPresenter.DesignViewClosed = DesignViewClosed;

            _mainViewModel.DesignViewModels.Add(designViewModel);
        }

        private void DesignViewClosed(IDesignPresenter designPresenter)
        {
            var designViewModel = designPresenter.View.DataContext as IDesignViewModel;
            var designView = designPresenter.View;

            _mainViewModel.DesignViewModels.Remove(designViewModel);
            designView.DataContext = null;            
            designPresenter.DesignViewClosed = null;
        }
    }
}
