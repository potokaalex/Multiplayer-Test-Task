using CodeBase.Infrastructure.Project.Services.Data;
using CodeBase.Infrastructure.Project.Services.Network;
using CodeBase.Infrastructure.Project.Services.SceneLoader;
using CodeBase.Infrastructure.Project.Services.StateMachine;

namespace CodeBase.Infrastructure.Project.States
{
    public class BootstrapState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly INetworkService _networkService;
        private readonly IDataProvider _dataProvider;
        private readonly ISceneLoader _sceneLoader;

        public BootstrapState(IStateMachine stateMachine, INetworkService networkService, IDataProvider dataProvider,
            ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _networkService = networkService;
            _dataProvider = dataProvider;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            var projectData = _dataProvider.Get<ProjectStaticData>();
            
            _networkService.Initialize(projectData.LobbySceneName, 2);
            _sceneLoader.LoadScene(projectData.LoadingSceneName, NetworkConnect);
        }

        private void NetworkConnect() =>
            _networkService.Connect(_stateMachine.SwitchTo<LoadLobbyState>);
    }
}