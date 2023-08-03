using CodeBase.Infrastructure.Project.Services.Data;
using CodeBase.Infrastructure.Project.Services.SceneLoader;
using CodeBase.Infrastructure.Project.Services.StateMachine;

namespace CodeBase.Infrastructure.Project.States
{
    public class LoadLobbyState : IState
    {
        private readonly IDataProvider _dataProvider;
        private readonly ISceneLoader _sceneLoader;

        public LoadLobbyState(IDataProvider dataProvider, ISceneLoader sceneLoader)
        {
            _dataProvider = dataProvider;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            var projectData = _dataProvider.Get<ProjectStaticData>();

            _sceneLoader.LoadScene(projectData.LoadingSceneName,
                () => _sceneLoader.LoadScene(projectData.LobbySceneName));
        }
    }
}