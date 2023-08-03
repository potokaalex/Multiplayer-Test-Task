using CodeBase.Infrastructure.Project.Services.Data;
using CodeBase.Infrastructure.Project.Services.Network;
using CodeBase.Infrastructure.Project.Services.SceneLoader;
using CodeBase.Infrastructure.Project.Services.StateMachine;

namespace CodeBase.Infrastructure.Project.States
{
    public class LoadGameState : IState
    {
        private readonly IDataProvider _dataProvider;
        private readonly ISceneLoader _sceneLoader;
        private readonly INetworkService _networkService;

        public LoadGameState(IDataProvider dataProvider, ISceneLoader sceneLoader, INetworkService networkService)
        {
            _dataProvider = dataProvider;
            _sceneLoader = sceneLoader;
            _networkService = networkService;
        }

        public void Enter()
        {
            var projectData = _dataProvider.Get<ProjectStaticData>();

            _sceneLoader.LoadScene(projectData.LoadingSceneName,
                () => _networkService.LoadGameScene(projectData.GameSceneName));
        }
    }
}