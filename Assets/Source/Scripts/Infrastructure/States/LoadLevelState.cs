using Source.Scripts.Services.Factory;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.Race;

namespace Source.Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;
        private readonly IRaceService _raceService;

        public LoadLevelState(
            GameStateMachine stateMachine, 
            SceneLoader sceneLoader,
            IGameFactory gameFactory,
            IPersistentProgressService progressService,
            IRaceService raceService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _progressService = progressService;
            _raceService = raceService;
        }
        public void Enter(string sceneName)
        {
            CleanUp();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();
            _stateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            _raceService.PrepareToRace();
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }

        private void CleanUp()
        {
            _gameFactory.CleanUp();
        }
    }
}