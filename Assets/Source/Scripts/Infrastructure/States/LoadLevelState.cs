using Cysharp.Threading.Tasks;
using Source.Scripts.Infrastructure.AssetManagement;
using Source.Scripts.Services.Factory;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.Race;
using Source.Scripts.UI.Factory;

namespace Source.Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;
        private readonly IPersistentProgressService _progressService;
        private readonly IRaceService _raceService;
        private readonly IAssets _assets;

        public LoadLevelState(
            IGameStateMachine stateMachine, 
            SceneLoader sceneLoader,
            IGameFactory gameFactory,
            IUIFactory uiFactory,
            IPersistentProgressService progressService,
            IRaceService raceService,
            IAssets assets)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
            _progressService = progressService;
            _raceService = raceService;
            _assets = assets;
        }
        public void Enter(string sceneName)
        {
            CleanUp();
            _sceneLoader.Load(sceneName, () => OnLoaded().Forget());
        }

        public void Exit()
        {
        }

        private async UniTaskVoid OnLoaded()
        {
            await InitUI();
            InitGameWorld();
            InformProgressReaders();
            _stateMachine.Enter<RacePrepareState>();
        }

        private async UniTask InitUI() => 
            await _uiFactory.CreateUIRoot();

        private void InitGameWorld() => 
            _raceService.PrepareToRace();

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }

        private void CleanUp()
        {
            _gameFactory.Cleanup();
            _uiFactory.Cleanup();
            _raceService.Cleanup();
            _assets.Cleanup();

            _gameFactory.WarmUp();
            _uiFactory.WarmUp();
        }
    }
}