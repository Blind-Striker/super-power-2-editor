using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Waf.Applications;
using System.Waf.Applications.Services;
using System.Windows.Forms;
using Akka.Actor;
using SuperPowerEditor.Base.BizLogic.Actors;
using SuperPowerEditor.Base.BizLogic.Actors.Commands;
using SuperPowerEditor.Base.BizLogic.Models;
using SuperPowerEditor.Base.DataAccess.Entities;
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
        private readonly Func<Type, IPresenter> _presenterFactory;

        private readonly IMainViewModel _mainViewModel;
        private IDesignViewModel _currentDesignViewModel;

        private IActorRef _mainPresenterRef;

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

        internal void OnModMetadataLoaded(ModMetadata eventModMetadata)
        {
            _modMetadata = eventModMetadata;

            _mainViewModel.MainMenuViewModel.CountryOperationsEnabled = true;
        }

        internal void OnDesignsLoaded(IEnumerable<Design> eventDesigns)
        {
            _currentDesignViewModel.Designs = new ObservableCollection<Design>(eventDesigns);
        }

        private void InitializeActors()
        {
            _mainPresenterRef = _applicationActorContext.ActorSystem.ActorOf(Props.Create(() => new MainPresenterActor(this)).WithDispatcher("akka.actor.synchronized-dispatcher"));
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

            var openGolemModCommand = new OpenGolemModCommand(golemModFilePath, _mainPresenterRef);

            _mainPresenterRef.Tell(openGolemModCommand);
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

                var openModDirectoryCommand = new OpenModDirectoryCommand(directoryPath, _mainPresenterRef);

                _mainPresenterRef.Tell(openModDirectoryCommand);
            }
        }

        private void OnOpenDesignsClicked()
        {
            // TODO: Error handling try remove akka.actor.synchronized-dispatcher

            _currentDesignViewModel = new DesignViewModel()
            {
                TabHeaderTitle = "Desings",
                CloseCommand = new DelegateCommand(OnDesignViewClosed)
            };

            _mainViewModel.TabViewModels.Add(_currentDesignViewModel);
            _currentDesignViewModel.ContentIsSelected = true;

            _mainPresenterRef.Tell(new LoadDesignsCommand(_mainPresenterRef, _modMetadata.ModDatabase));
        }

        private void OnDesignViewClosed()
        {
            _mainViewModel.TabViewModels.Remove(_currentDesignViewModel);
            _currentDesignViewModel = null;

            _mainPresenterRef.Tell(new CloseDesignViewCommand());
        }
    }
}
