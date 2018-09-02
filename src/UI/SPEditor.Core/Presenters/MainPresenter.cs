using System.Waf.Applications;
using System.Waf.Applications.Services;
using System.Windows.Forms;
using Akka.Actor;
using SuperPowerEditor.Base.BizLogic.Actors;
using SuperPowerEditor.Base.BizLogic.Models;
using SuperPowerEditor.UI.SPEditor.Core.Actors;
using SuperPowerEditor.UI.SPEditor.Core.Actors.Commands;
using SuperPowerEditor.UI.SPEditor.Core.Contracts;
using SuperPowerEditor.UI.SPEditor.Core.ViewModels.Main;
using SuperPowerEditor.UI.SPEditor.Core.Views;

namespace SuperPowerEditor.UI.SPEditor.Core.Presenters
{
    public class MainPresenter : BasePresenter<IMainView, IMainPresenter>, IMainPresenter
    {
        private readonly IFileDialogService _fileDialogService;
        private readonly IApplicationActorContext _applicationActorContext;

        private readonly IMainViewModel _mainViewModel;

        private IActorRef _mainMenuActorRef;
        private IActorRef _mainPresenterRef;
        private IActorRef _modMetadataActorRef;

        public MainPresenter(IMainView view, IFileDialogService fileDialogService, IApplicationActorContext applicationActorContext) : base(view)
        {
            _fileDialogService = fileDialogService;
            _applicationActorContext = applicationActorContext;
            _mainViewModel = new MainViewModel();

            InitializeViewModels();

            InitializeActors();
        }

        private void InitializeActors()
        {
            _mainPresenterRef = _applicationActorContext.ActorSystem.ActorOf(Props.Create(() => new MainPresenterActor(this)));
            
            _modMetadataActorRef = _applicationActorContext.ActorSystem.ActorOf(Props.Create(() => new ModMetadataActor()));

            _mainMenuActorRef = _applicationActorContext.ActorSystem.ActorOf(Props.Create(() => new MainMenuActor(_modMetadataActorRef, _mainViewModel.MainMenuViewModel)));
        }

        private void InitializeViewModels()
        {
            _mainViewModel.MainMenuViewModel = new MainMenuViewModel()
            {
                OpenGolemModCommand = new DelegateCommand(OnGolemOpenModClicked, () => true),
                OpenModCommand = new DelegateCommand(OpenOpenModClicked, () => true)
            };

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

        public void SetModMetadata(ModMetadata eventModMetadata)
        {
            
        }
    }
}
